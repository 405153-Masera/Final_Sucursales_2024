namespace Backend.Dtos
{
    public class SucursalDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public Guid TipoId { get; set; }
        public Guid ProvinciaId { get; set; }
        public string Telefono { get; set; } = null!;
        public string NombreTitular { get; set; } = null!;
        public string ApellidoTitular { get; set; } = null!;
    }
}
