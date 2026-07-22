using FineArts.Areas.Identity.Data;
using FineArts.Models;

using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FineArts.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _context;

        private readonly UserManager<user> _userManager;

        public StudentController(
            ApplicationDBContext context,
            UserManager<user> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Competitions()
        {
            return View();
        }

        public IActionResult MyPaintings()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult Awards()
        {
            return View();
        }

        public IActionResult Exhibitions()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
        // GET: Student



        // GET: Student
        public async Task<IActionResult> Index()
        {
            var students = await _context.students
                .Include(s => s.User)
                .ToListAsync();

            return View(students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            // Get the logged-in Identity user
            var identityUser = await _userManager.GetUserAsync(User);

            if (identityUser == null)
            {
                return Challenge(); // User is not logged in
            }

            // Check if the user is already registered as a student
            bool alreadyRegistered = await _context.students
                .AnyAsync(s => s.UserId == identityUser.Id);

            if (alreadyRegistered)
            {
                ModelState.AddModelError("", "You are already registered as a student.");
                return View(student);
            }

            // Link the student record to the logged-in user
            student.UserId = identityUser.Id;

            // Save the student
            _context.students.Add(student);
            await _context.SaveChangesAsync();

            // Assign the Student role
            if (!await _userManager.IsInRoleAsync(identityUser, "Student"))
            {
                await _userManager.AddToRoleAsync(identityUser, "Student");
            }

            TempData["Success"] = "Student registration completed successfully.";

            return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
    }
}
//        // GET: Student/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.students.FindAsync(id);

//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // POST: Student/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Student student)
//        {
//            if (id != student.StudentId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(student);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StudentExists(student.StudentId))
//                    {
//                        return NotFound();
//                    }

//                    throw;
//                }

//                return RedirectToAction(nameof(Index));
//            }

//            return View(student);
//        }

//        // GET: Student/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.students
//                .Include(s => s.User)
//                .FirstOrDefaultAsync(m => m.StudentId == id);

//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // POST: Student/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var student = await _context.students.FindAsync(id);

//            if (student != null)
//            {
//                _context.students.Remove(student);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        private bool StudentExists(int id)
//        {
//            return _context.students.Any(e => e.StudentId == id);

//        }
//    }
//}