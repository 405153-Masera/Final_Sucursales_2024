using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Impl
{
    public class ConfiguracionRepository : IConfiguracionRepository
    {
        private readonly Context _context;

        public ConfiguracionRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Configuracion>> GetAllConfiguracionAsync()
        {
            var configuraciones = await _context.Configuraciones.ToListAsync();
            return configuraciones;
        }
    }
}
