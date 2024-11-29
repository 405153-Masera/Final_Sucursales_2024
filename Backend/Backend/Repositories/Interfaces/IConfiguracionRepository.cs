using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface IConfiguracionRepository
    {
        Task<List<Configuracion>> GetAllConfiguracionAsync();
    }
}
