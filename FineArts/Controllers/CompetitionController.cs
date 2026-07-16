using FineArts.Areas.Identity.Data;
using FineArts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FineArts.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CompetitionController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Competition
        public async Task<IActionResult> Index()
        {
            var competitions = await _context.Competition
                .Include(c => c.Staff)
                .ToListAsync();

            return View(competitions);
        }

        // GET: Competition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var competition = await _context.Competition
                .Include(c => c.Staff)
                .FirstOrDefaultAsync(c => c.CompetitionId == id);

            if (competition == null)
                return NotFound();

            return View(competition);
        }

        // GET: Competition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competition/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Competition competition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(competition);
        }

        // GET: Competition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var competition = await _context.Competition.FindAsync(id);

            if (competition == null)
                return NotFound();

            return View(competition);
        }

        // POST: Competition/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Competition competition)
        {
            if (id != competition.CompetitionId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitionExists(competition.CompetitionId))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(competition);
        }

        // GET: Competition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var competition = await _context.Competition
                .Include(c => c.Staff)
                .FirstOrDefaultAsync(c => c.CompetitionId == id);

            if (competition == null)
                return NotFound();

            return View(competition);
        }

        // POST: Competition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competition = await _context.Competition.FindAsync(id);

            if (competition != null)
            {
                _context.Competition.Remove(competition);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CompetitionExists(int id)
        {
            return _context.Competition.Any(e => e.CompetitionId == id);
        }
    }
}