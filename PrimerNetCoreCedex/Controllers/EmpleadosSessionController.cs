using Microsoft.AspNetCore.Mvc;
using PrimerNetCoreCedex.Extensions;
using PrimerNetCoreCedex.Models;
using PrimerNetCoreCedex.Repositories;

namespace PrimerNetCoreCedex.Controllers
{
    public class EmpleadosSessionController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosSessionController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> SessionEmpleados(int? idempleado)
        {
            if (idempleado != null)
            {
                //BUSCAMOS EL EMPLEADO
                Empleado emp = await this.repo.FindEmpleadoAsync(idempleado.Value);
                //DENTRO DE SESSION TENDREMOS UNA COLECCION DE EMPLEADOS
                List<Empleado> empleadosSession;
                if (HttpContext.Session.GetObject("EMPLEADOS") != null)
                {
                    empleadosSession = HttpContext.Session.GetObject("EMPLEADOS");
                }
                else
                {
                    empleadosSession = new List<Empleado>();
                }
                //AGREGAMOS EL NUEVO EMPLEADO A LA COLECCION
                empleadosSession.Add(emp);
                //ALMACENAMOS LA COLECCION EMPLEADOS EN SESSION
                HttpContext.Session.SetObject("EMPLEADOS", empleadosSession);
                ViewData["MENSAJE"] = "Numero de empleados almacenados: " + empleadosSession.Count;
            }
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
            return View(empleados);
        }

        public IActionResult CarritoEmpleados()
        {
            return View();
        }

        public IActionResult SumaSalarial()
        {
            return View();
        }

        public async Task<IActionResult> SessionSalarios(int? salario)
        {
            //TENGO QUE SABER SI ES LA PRIMERA VEZ QUE MUESTRA LA PAGINA
            //O SI YA HE RECIBIDO EL SALARIO
            if (salario != null)
            {
                //ALMACENAREMOS EN SESSION UN NUMERO
                //DEBEMOS SABER SI DICHO NUMERO YA ESTA DENTRO DE LA SESION
                int sumaSalarial = 0;
                if (HttpContext.Session.GetString("SUMASALARIAL") != null)
                {
                    //YA TENEMOS UN VALOR DENTRO DE SESSION
                    sumaSalarial = int.Parse(HttpContext.Session.GetString("SUMASALARIAL"));
                }
                //SUMAMOS EL NUEVO SALARIO QUE NOS HAN DADO
                sumaSalarial += salario.Value;
                //ALMACENAMOS LA NUEVA SUMA SALARIAL DENTRO DE SESSION
                HttpContext.Session.SetString("SUMASALARIAL", sumaSalarial.ToString());
                ViewData["MENSAJE"] = "Salario almacenado: " + salario.Value;
            }
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
            return View(empleados);
        }
    }
}
