using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Impl
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly Context _context;
        public SucursalRepository(Context context)
        {
            _context = context;
        }

        public async Task<Sucursal?> GetSucursalAsync()
        {
           var sucursal = await _context.Sucursales.Where(s => s.Provincia.Nombre != "Buenos Aires")
                .OrderByDescending(s => s.FechaAlta)
                .Include(s => s.Tipo)
                .Include(s => s.Provincia)
                .FirstOrDefaultAsync();
            return sucursal;
        }

        public async Task<Sucursal> PostSucursal(Sucursal sucursal)
        {
            var sucursalPost = await _context.Sucursales.AddAsync(sucursal);
            await _context.SaveChangesAsync();
            return sucursalPost.Entity;
        }

        public async Task<Sucursal?> PutSucursal(Guid id, Sucursal sucursal)
        {
            var sucursalPut = await _context.Sucursales.FindAsync(id);

            if (sucursalPut == null) return null;

            sucursalPut.Nombre = sucursal.Nombre;
            sucursalPut.Ciudad = sucursal.Ciudad;
            sucursalPut.Telefono = sucursal.Telefono;
            sucursalPut.NombreTitular = sucursal.NombreTitular;
            sucursalPut.ApellidoTitular = sucursal.ApellidoTitular;
            //sucursalPut.Tipo = sucursal.Tipo;
            //sucursalPut.Provincia = sucursal.Provincia;

            //Es mejor asi para no pasar todo el objeto
            sucursalPut.ProvinciaId = sucursal.ProvinciaId;
            sucursalPut.TipoId = sucursal.TipoId;
            
            await _context.SaveChangesAsync();
            return sucursalPut;
        }
    }
}
