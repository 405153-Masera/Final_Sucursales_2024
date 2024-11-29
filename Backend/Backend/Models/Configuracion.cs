using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Configuracion
    {
        [Key]
        public Guid Id { get; set; }
        
        // = null!; esto indica que el valor no puede ser nulo
        public string Nombre { get; set; } = null!;
        public string Valor { get; set; } = null!;
    }
}
