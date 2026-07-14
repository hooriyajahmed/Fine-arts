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
            public IActionResult Create()
            {
                return View();
            }

            // POST: Staff/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Staff staff)
            {
                if (!ModelState.IsValid)
                {
                    return View(staff);
                }

                // Get the logged-in Identity user
                var identityUser = await _userManager.GetUserAsync(User);

                if (identityUser == null)
                {
                    return Challenge(); // User is not logged in
                }

                // Check if the user is already registered as a staff
                bool alreadyRegistered = await _context.staffs
                    .AnyAsync(s => s.UserId == identityUser.Id);

                if (alreadyRegistered)
                {
                    ModelState.AddModelError("", "You are already registered as a staff.");
                    return View(staff);
                }

                // Link the student record to the logged-in user
                staff.UserId = identityUser.Id;

                // Save the staff
                _context.staffs.Add(staff);
                await _context.SaveChangesAsync();

                // Assign the Staff role
                if (!await _userManager.IsInRoleAsync(identityUser, "Staff"))
                {
                    await _userManager.AddToRoleAsync(identityUser, "Staff");
                }

                TempData["Success"] = "Staff registration completed successfully.";

                return RedirectToAction("Index", "Home");
            }
        
        }
}
