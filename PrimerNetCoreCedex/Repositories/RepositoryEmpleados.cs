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

        #region EMPLEADOS

        public async Task<Empleado> FindEmpleadoAsync(int id)
        {
            return await this.context.Empleados
                .FirstOrDefaultAsync(z => z.IdEmpleado == id);
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        } 

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            return await this.context.Empleados
                .Where(z => z.Oficio == oficio).ToListAsync();
        }

        #endregion

        #region DEPARTAMENTOS

        #endregion
    }
}
