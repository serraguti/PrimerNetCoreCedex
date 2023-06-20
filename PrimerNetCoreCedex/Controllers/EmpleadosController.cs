using Microsoft.AspNetCore.Mvc;
using PrimerNetCoreCedex.Models;
using PrimerNetCoreCedex.Repositories;

namespace PrimerNetCoreCedex.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        //AQUI DIBUJAMOS TODOS LOS EMPLEADOS
        public async Task<IActionResult> Index()
        {
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
            return View(empleados);
        }
    }
}
