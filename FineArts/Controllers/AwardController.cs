//using FineArts.Areas.Identity.Data;
//using FineArts.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace FineArts.Controllers
//{
//    public class AwardController : Controller
//    {
//        private readonly ApplicationDBContext _context;

//        public AwardController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: Award
//        public async Task<IActionResult> Index()
//        {
//            var awards = await _context.awards
//                .Include(a => a.Student)
//                .Include(a => a.Competition)
//                .ToListAsync();

//            return View(awards);
//        }

//        // GET: Award/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var award = await _context.awards
//                .Include(a => a.Student)
//                .Include(a => a.Competition)
//                .FirstOrDefaultAsync(a => a.AwardId == id);

//            if (award == null)
//            {
//                return NotFound();
//            }

//            return View(award);
//        }

//        // GET: Award/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Award/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Award award)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.awards.Add(award);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(award);
//        }

//        // GET: Award/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var award = await _context.awards.FindAsync(id);

//            if (award == null)
//            {
//                return NotFound();
//            }

//            return View(award);
//        }

//        // POST: Award/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Award award)
//        {
//            if (id != award.AwardId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.awards.Update(award);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AwardExists(award.AwardId))
//                    {
//                        return NotFound();
//                    }

//                    throw;
//                }

//                return RedirectToAction(nameof(Index));
//            }

//            return View(award);
//        }

//        // GET: Award/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var award = await _context.awards
//                .Include(a => a.Student)
//                .Include(a => a.Competition)
//                .FirstOrDefaultAsync(a => a.AwardId == id);

//            if (award == null)
//            {
//                return NotFound();
//            }

//            return View(award);
//        }

//        // POST: Award/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var award = await _context.awards.FindAsync(id);

//            if (award != null)
//            {
//                _context.awards.Remove(award);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        private bool AwardExists(int id)
//        {
//            return _context.awards.Any(e => e.AwardId == id);
//        }
//    }
//}