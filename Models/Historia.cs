namespace SistemaIngreso.Models
{
    public class Historia
    {
        public int Id { set; get; }
        public DateOnly HoraEntrada { get; set; }
        public DateOnly HoraSalida { get; set; }
        public int IdEmpleado { get; set; } 
    }
}