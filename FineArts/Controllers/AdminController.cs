<<<<<<< Updated upstream
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using FineArts.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
>>>>>>> Stashed changes

namespace FineArts.Controllers
{
    public class AdminController : Controller
    {
<<<<<<< Updated upstream
        public IActionResult Index()
        {
            return View();
        }
    }
}
=======
        private readonly ApplicationDBContext dbcontext;

        public AdminController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult allcompetitions()
        {
            var data = dbcontext.compettions.ToList();
            return View(data);
        }
    }
}
>>>>>>> Stashed changes
