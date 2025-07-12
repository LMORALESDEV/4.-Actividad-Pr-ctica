using Actividad4LengPro3.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengPro3.Datos
{
    public class Actividad4DbContext : DbContext
    {
        public Actividad4DbContext(DbContextOptions options) : base(options)
        {
        }

        protected Actividad4DbContext()
        {
        }

        public DbSet<EstudiantesViewModel> Estudiantes { get; set; }
        public DbSet<MateriaViewModel> Materias { get; set; }
        public DbSet<CalificacionViewModel> Calificaciones { get; set; }
    }
}
