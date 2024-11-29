using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Provincia
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
