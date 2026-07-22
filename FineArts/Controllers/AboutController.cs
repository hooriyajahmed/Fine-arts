using Microsoft.AspNetCore.Mvc;

namespace FineArts.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
