using Microsoft.AspNetCore.Mvc;
using PrimerNetCoreCedex.Helpers;

namespace PrimerNetCoreCedex.Controllers
{
    public class UtilidadesController : Controller
    {
        private HelperPathProvider helperPathProvider;

        public UtilidadesController(HelperPathProvider helperPathProvider)
        {
            this.helperPathProvider = helperPathProvider;
        }

        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string fileName = file.FileName;
            //SIEMPRE QUE TRABAJEMOS CON FILES, DEBEMOS UTILIZAR 
            //Path.Combine
            string path = this.helperPathProvider.MapPath(fileName, Folders.Images);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            ViewData["MENSAJE"] = "Fichero subido a " + path;
            return View();
        }
    }
}
