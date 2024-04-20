using Microsoft.EntityFrameworkCore;
using SistemaIngreso.Models;

namespace SistemaIngreso.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){
            
        }

        //Registramos nuestros modelos
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Historia> Historial { get; set; }

        /* Configuracion para la conexion de la base de datos */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historia>()
            .HasOne(h => h.Empleado)
            .WithMany(p => p.Historial)
            .HasForeignKey(h => h.IdEmpleado)
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}