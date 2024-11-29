using AutoMapper;
using Backend.Dtos;
using Backend.Mappers;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Intrerfaces;
using Backend.Validators;

namespace Backend.Services.Impl
{
    public class ApiService : IApiService
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IConfiguracionRepository _configuracionRepository;
        private readonly IMapper _mapper;
        private readonly SucursalValidator _validator;
        public ApiService(ISucursalRepository sucursalRepository, IConfiguracionRepository configuracionRepository,
                            IMapper mapper, SucursalValidator validator)
        {
            _sucursalRepository = sucursalRepository;
            _configuracionRepository = configuracionRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<List<ConfiguracionDto>>> GetAllConfigsAsync()
        {
            var response = new BaseResponse<List<ConfiguracionDto>>();
            try
            {
                var configuraciones = await _configuracionRepository.GetAllConfiguracionAsync();
                response.Data = _mapper.Map<List<ConfiguracionDto>>(configuraciones);
                response.Success = true;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Error al obtener las configuraciones";
                throw;
            }
            return response;
        }

        public async Task<BaseResponse<SucursalDto>> GetSucursalAsync()
        {
            var response = new BaseResponse<SucursalDto>();
            try
            {
                var sucursal = await _sucursalRepository.GetSucursalAsync();
                response.Data = _mapper.Map<SucursalDto>(sucursal);
                response.Success = true;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Error al obtener la sucursal";
                throw;
            }
            return response;
        }

        public async Task<BaseResponse<SucursalDto>> PostSucursalAsync(SucursalDto sucursalDto)
        {
            var response = new BaseResponse<SucursalDto>();

            var validacion = await _validator.ValidateAsync(sucursalDto);

            if (!validacion.IsValid)
            {
                var errorMessages = string.Join(", ", validacion.Errors.Select(x => x.ErrorMessage));
                response.Success = false;
                response.Message = errorMessages;
                return response;
            }

            try
            {
         
                var sucursal = _mapper.Map<Sucursal>(sucursalDto);
                sucursal.Id = Guid.NewGuid();
                sucursal.FechaAlta = DateTime.Now;

                sucursal = await _sucursalRepository.PostSucursal(sucursal);
                response.Data = _mapper.Map<SucursalDto>(sucursal);
                response.Success = true;
                response.Message = "Sucursal creada correctamente";
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Error al añadir la sucursal";
                throw;
            }
            return response;
        }

        public async Task<BaseResponse<SucursalDto>> PutSucursalAsync(SucursalDto sucursalDto)
        {
            var response = new BaseResponse<SucursalDto>();

            var validacion = await _validator.ValidateAsync(sucursalDto);

            if (!validacion.IsValid)
            {
                var errorMessages = string.Join(", ", validacion.Errors.Select(x => x.ErrorMessage));
                response.Success = false;
                response.Message = errorMessages;
                return response;
            }

            try
            {

                var sucursal = _mapper.Map<Sucursal>(sucursalDto);

                sucursal = await _sucursalRepository.PutSucursal(sucursal);
                response.Data = _mapper.Map<SucursalDto>(sucursal);
                response.Success = true;
                response.Message = "Sucursal actualizada correctamente";
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Error al actualizar la sucursal";
                throw;
            }
            return response;
        }
    }
}
