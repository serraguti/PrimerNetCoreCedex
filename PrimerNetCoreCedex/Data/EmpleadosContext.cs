using Microsoft.EntityFrameworkCore;
using PrimerNetCoreCedex.Models;

namespace PrimerNetCoreCedex.Data
{
    public class EmpleadosContext: DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
