using Microsoft.AspNetCore.Mvc;
using PrimerNetCoreCedex.Models;

namespace PrimerNetCoreCedex.Controllers
{
    public class InformacionController : Controller
    {
        public IActionResult ControllerView()
        {
            ViewData["NOMBRE"] = "Alumno martes";
            ViewData["EDAD"] = 41;
            Persona persona = new Persona();
            persona.Nombre = "Persona Model";
            persona.Edad = 16;
            persona.Email = "persona@gmail.com";
            return View(persona);
        }

        public IActionResult ViewControllerGet
            (string app, string tecnologia)
        {
            ViewData["DATOS"] = "Application " + app + " " + tecnologia;
            return View();
        }

        //NECESITAMOS DOS METODOS
        [HttpGet]
        public IActionResult ViewControllerPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewControllerPost
            (Persona persona)
        {
            ViewData["MENSAJE"] =
                "Nombre: " + persona.Nombre + ", " + 
                persona.Email
                + ", Edad: " + persona.Edad;
            return View();
        }
    }
}
