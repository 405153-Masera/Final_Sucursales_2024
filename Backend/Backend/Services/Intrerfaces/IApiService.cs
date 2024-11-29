using Backend.Dtos;

namespace Backend.Services.Intrerfaces
{
    public interface IApiService
    {
        Task<BaseResponse<SucursalDto>> GetSucursalAsync();
        Task<BaseResponse<SucursalDto>> PostSucursalAsync(SucursalDto sucursalDto);
        Task<BaseResponse<SucursalDto>> PutSucursalAsync(SucursalDto sucursalDto);
        Task<BaseResponse<List<ConfiguracionDto>>> GetAllConfigsAsync();
    }
}
