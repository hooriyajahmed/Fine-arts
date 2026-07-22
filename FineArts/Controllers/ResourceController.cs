using Microsoft.AspNetCore.Mvc;

namespace FineArts.Controllers
{
    public class ResourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
