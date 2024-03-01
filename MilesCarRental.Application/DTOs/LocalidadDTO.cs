namespace MilesCarRental.Application.DTOs
{
    public class LocalidadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int CiudadId { get; set; }
    }
}
