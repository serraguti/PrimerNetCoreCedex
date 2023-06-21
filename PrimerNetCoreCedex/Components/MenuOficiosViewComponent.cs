using Microsoft.AspNetCore.Mvc;
using PrimerNetCoreCedex.Repositories;

namespace PrimerNetCoreCedex.Components
{
    public class MenuOficiosViewComponent: ViewComponent
    {
        private RepositoryEmpleados repo;

        public MenuOficiosViewComponent(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        //EXISTE UN METODO PARA ENVIAR LOS DATOS A UNA VISTA QUE DIBUJAREMOS
        //INTEGRADA EN LAYOUT
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<string> oficios = await this.repo.GetOficiosAsync();
            return View(oficios);
        }
    }
}
