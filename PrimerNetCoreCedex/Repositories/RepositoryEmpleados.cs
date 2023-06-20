using Microsoft.EntityFrameworkCore;
using PrimerNetCoreCedex.Data;
using PrimerNetCoreCedex.Models;

namespace PrimerNetCoreCedex.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        } 
    }
}
