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

        //NECESITAMOS DOS METODOS.  UN GET PARA MOSTRAR LA VISTA
        public async Task<IActionResult> EmpleadosOficio()
        {
            List<string> oficios = await this.repo.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View();
        }

        //UN POST PARA MOSTRAR LOS EMPLEADOS QUE HEMOS ENCONTRADO
        [HttpPost]
        public async Task<IActionResult> EmpleadosOficio(string oficio)
        {
            List<Empleado> empleados = await this.repo.GetEmpleadosOficioAsync(oficio);
            List<string> oficios = await this.repo.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }
    }
}
