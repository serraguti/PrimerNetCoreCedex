using Microsoft.AspNetCore.Mvc;

namespace PrimerNetCoreCedex.Controllers
{
    public class InformacionController : Controller
    {
        public IActionResult ControllerView()
        {
            ViewData["NOMBRE"] = "Alumno martes";
            ViewData["EDAD"] = 41;
            return View();
        }
    }
}
