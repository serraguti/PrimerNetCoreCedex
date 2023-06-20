using Microsoft.AspNetCore.Mvc;
using PrimerNetCoreCedex.Helpers;

namespace PrimerNetCoreCedex.Controllers
{
    public class UtilidadesController : Controller
    {
        private HelperPathProvider helperPathProvider;
        private HelperMails helperMails;

        public UtilidadesController
            (HelperPathProvider helperPathProvider, HelperMails helperMails)
        {
            this.helperMails = helperMails;
            this.helperPathProvider = helperPathProvider;
        }

        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail
            (string para, string asunto, string cuerpo)
        {
            await this.helperMails.SendMailAsync(para, asunto, cuerpo);
            ViewData["MENSAJE"] = "Email enviado correctamente";
            return View();
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
