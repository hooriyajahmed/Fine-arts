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

//        private readonly ApplicationDBContext _context;

//        public StaffController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: Staff
//        public async Task<IActionResult> Index()
//        {
//            var staffs = await _context.staffs
//                .Include(s => s.User)
//                .ToListAsync();

//            return View(staffs);
//        }

//        // GET: Staff/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var staff = await _context.staffs
//                .Include(s => s.User)
//                .FirstOrDefaultAsync(m => m.StaffId == id);

//            if (staff == null)
//            {
//                return NotFound();
//            }

//            return View(staff);
//        }

//        // GET: Staff/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Staff/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Staff staff)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(staff);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(staff);
//        }

//        // GET: Staff/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var staff = await _context.staffs.FindAsync(id);

//            if (staff == null)
//            {
//                return NotFound();
//            }

//            return View(staff);
//        }

//        // POST: Staff/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Staff staff)
//        {
//            if (id != staff.StaffId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(staff);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StaffExists(staff.StaffId))
//                    {
//                        return NotFound();
//                    }

//                    throw;
//                }

//                return RedirectToAction(nameof(Index));
//            }

//            return View(staff);
//        }

//        // GET: Staff/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var staff = await _context.staffs
//                .Include(s => s.User)
//                .FirstOrDefaultAsync(m => m.StaffId == id);

//            if (staff == null)
//            {
//                return NotFound();
//            }

//            return View(staff);
//        }

//        // POST: Staff/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var staff = await _context.staffs.FindAsync(id);

//            if (staff != null)
//            {
//                _context.staffs.Remove(staff);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        private bool StaffExists(int id)
//        {
//            return _context.staffs.Any(e => e.StaffId == id);
//        }
//    }
//}
