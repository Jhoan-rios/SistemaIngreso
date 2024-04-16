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
    }
}