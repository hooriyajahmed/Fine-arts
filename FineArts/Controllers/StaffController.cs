using FineArts.Areas.Identity.Data;
using FineArts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FineArts.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<user> _userManager;

        public StaffController(
            ApplicationDBContext context,
            UserManager<user> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Staff
        public IActionResult Index()
        {
            return View();
        }

        // GET: Staff/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var identityUser = await _userManager.GetUserAsync(User);

            if (identityUser == null)
            {
                return Challenge();
            }

            // Already a Staff?
            if (await _context.staffs.AnyAsync(s => s.UserId == identityUser.Id))
            {
                TempData["Error"] = "You are already registered as Staff.";
                return RedirectToAction("Index", "Home");
            }

            // Already a Student?
            if (await _context.students.AnyAsync(s => s.UserId == identityUser.Id))
            {
                TempData["Error"] = "You are already registered as Student. You cannot become Staff.";
                return RedirectToAction("Index", "Home");
            }

            // Already has a pending request?
            if (await _context.staffRequests.AnyAsync(r =>
                r.UserId == identityUser.Id &&
                r.Status == "Pending"))
            {
                TempData["Error"] = "You already have a pending Staff request.";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffRequest request)
        {
            var identityUser = await _userManager.GetUserAsync(User);

            if (identityUser == null)
            {
                return Challenge();
            }

            // Automatically fill Identity data
            request.UserId = identityUser.Id;
            request.Email = identityUser.Email;

            // Remove validation for fields filled by the server
            ModelState.Remove(nameof(request.Email));
            ModelState.Remove(nameof(request.UserId));
            ModelState.Remove(nameof(request.User));

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            // Already Staff?
            if (await _context.staffs.AnyAsync(s => s.UserId == identityUser.Id))
            {
                ModelState.AddModelError("", "You are already registered as Staff.");
                return View(request);
            }

            // Already Student?
            if (await _context.students.AnyAsync(s => s.UserId == identityUser.Id))
            {
                ModelState.AddModelError("", "You are already registered as Student.");
                return View(request);
            }

            // Already has pending request?
            if (await _context.staffRequests.AnyAsync(r =>
                r.UserId == identityUser.Id &&
                r.Status == "Pending"))
            {
                ModelState.AddModelError("", "You already have a pending Staff request.");
                return View(request);
            }

            request.Status = "Pending";
            request.RequestDate = DateTime.Now;

            _context.staffRequests.Add(request);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Your staff registration request has been sent to the administrator.";

            return RedirectToAction("Index", "Home");
        }
    }
}