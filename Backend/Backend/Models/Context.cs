using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Configuracion> Configuraciones { get; set; }

    }
}
