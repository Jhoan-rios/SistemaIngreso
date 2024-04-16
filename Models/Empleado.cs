namespace SistemaIngreso.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public int IdHistorial { get; set; } 

    }
}