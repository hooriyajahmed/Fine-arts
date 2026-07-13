using FineArts.Areas.Identity.Data;
using FineArts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FineArts.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EvaluationController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Evaluation
        public async Task<IActionResult> Index()
        {
            var evaluations = await _context.evaluations
                .Include(e => e.Painting)
                .Include(e => e.Staff)
                .ToListAsync();

            return View(evaluations);
        }

        // GET: Evaluation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.evaluations
                .Include(e => e.Painting)
                .Include(e => e.Staff)
                .FirstOrDefaultAsync(m => m.EvaluationId == id);

            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // GET: Evaluation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evaluation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                _context.evaluations.Add(evaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(evaluation);
        }

        // GET: Evaluation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.evaluations.FindAsync(id);

            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Evaluation evaluation)
        {
            if (id != evaluation.EvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.evaluations.Update(evaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationExists(evaluation.EvaluationId))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(evaluation);
        }

        // GET: Evaluation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.evaluations
                .Include(e => e.Painting)
                .Include(e => e.Staff)
                .FirstOrDefaultAsync(m => m.EvaluationId == id);

            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await _context.evaluations.FindAsync(id);

            if (evaluation != null)
            {
                _context.evaluations.Remove(evaluation);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
            return _context.evaluations.Any(e => e.EvaluationId == id);
        }
    }
}