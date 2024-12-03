namespace Backend.Dtos
{
    public class GetSucursalDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string NombreTitular { get; set; } = null!;
        public string ApellidoTitular { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public Guid TipoId { get; set; }
        public Guid ProvinciaId { get; set; }
        public ProvinciaDto Provincia { get; set; } = null!;
    }
}
