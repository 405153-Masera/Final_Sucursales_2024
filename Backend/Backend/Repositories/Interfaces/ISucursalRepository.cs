using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface ISucursalRepository
    {
        Task<Sucursal?> GetSucursalAsync();
        Task<Sucursal?> PutSucursal(Sucursal sucursal);
        Task<Sucursal> PostSucursal(Sucursal sucursal);
    }
}
