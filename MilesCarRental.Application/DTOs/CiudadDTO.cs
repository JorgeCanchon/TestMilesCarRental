namespace MilesCarRental.Application.DTOs
{
    public class CiudadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int PaisId { get; set; }
    }
}
