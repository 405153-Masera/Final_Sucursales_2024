using Backend.Dtos;

namespace Backend.Services.Intrerfaces
{
    public interface IApiService
    {
        Task<BaseResponse<GetSucursalDto>> GetSucursalAsync();
        Task<BaseResponse<SucursalDto>> PostSucursalAsync(SucursalDto sucursalDto);
        Task<BaseResponse<SucursalDto>> PutSucursalAsync(Guid id ,SucursalDto sucursalDto);
        Task<BaseResponse<List<ConfiguracionDto>>> GetAllConfigsAsync();
    }
}
