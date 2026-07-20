using FineArts.Areas.Identity.Data;
using FineArts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FineArts.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<user> _userManager;

        public AdminController(
            ApplicationDBContext context,
            UserManager<user> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Dashboard
        public IActionResult Index()
        {
            return View();
        }

        // Show all staff requests
        public async Task<IActionResult> StaffRequests()
        {
            var requests = await _context.staffRequests
                .Include(r => r.User)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();

            return View(requests);
        }

        // Approve Staff Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var request = await _context.staffRequests
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            // Already approved?
            if (request.Status == "Approved")
            {
                TempData["Error"] = "This request has already been approved.";
                return RedirectToAction(nameof(StaffRequests));
            }

            // Already exists as Staff?
            bool alreadyStaff = await _context.staffs
                .AnyAsync(s => s.UserId == request.UserId);

            if (alreadyStaff)
            {
                TempData["Error"] = "This user is already registered as Staff.";
                return RedirectToAction(nameof(StaffRequests));
            }

            // Create Staff record
            Staff staff = new Staff
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Email = request.Email,
                Phone = request.Phone,
                JoiningDate = request.JoiningDate,
                Subject = request.Subject,
                ClassHandling = request.ClassHandling,
                Remarks = request.Remarks
            };

            _context.staffs.Add(staff);

            // Update request status
            request.Status = "Approved";

            // Assign Staff role
            var identityUser = await _userManager.FindByIdAsync(request.UserId);

            if (identityUser != null)
            {
                if (!await _userManager.IsInRoleAsync(identityUser, "Staff"))
                {
                    await _userManager.AddToRoleAsync(identityUser, "Staff");
                }
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Staff request approved successfully.";

            return RedirectToAction(nameof(StaffRequests));
        }

        // Reject Staff Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var request = await _context.staffRequests
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = "Rejected";

            await _context.SaveChangesAsync();

            TempData["Success"] = "Staff request rejected.";

            return RedirectToAction(nameof(StaffRequests));
        }
    }
}
