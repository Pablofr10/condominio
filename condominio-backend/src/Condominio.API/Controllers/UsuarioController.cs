using Microsoft.AspNetCore.Mvc;

namespace Condominio.API.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioController()
        {
            
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}