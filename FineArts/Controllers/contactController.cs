using Microsoft.AspNetCore.Mvc;

namespace FineArts.Controllers
{
    public class contactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
