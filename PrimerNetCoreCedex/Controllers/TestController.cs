using Microsoft.AspNetCore.Mvc;

namespace PrimerNetCoreCedex.Controllers
{
    public class TestController : Controller
    {
        public IActionResult PrimeraPagina()
        {
            return View();
        }

        public IActionResult Prueba()
        {
            return View();
        }
    }
}
