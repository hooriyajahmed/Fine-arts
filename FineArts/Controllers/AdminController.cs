using Microsoft.AspNetCore.Mvc;

namespace FineArts.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
