namespace MilesCarRental.Application.DTOs
{
    public class VehiculoDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public int LocalidadRecogidaId { get; set; }
        public int LocalidadDevolucionId { get; set; }
    }
}
