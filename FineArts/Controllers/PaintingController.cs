using FineArts.Areas.Identity.Data;
using FineArts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FineArts.Controllers
{
    public class PaintingController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PaintingController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Painting
        public async Task<IActionResult> Index()
        {
            var paintings = await _context.paintings
                .Include(p => p.Student)
                .Include(p => p.Competition)
                .ToListAsync();

            return View(paintings);
        }

        // GET: Painting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var painting = await _context.paintings
                .Include(p => p.Student)
                .Include(p => p.Competition)
                .FirstOrDefaultAsync(p => p.PaintingId == id);

            if (painting == null)
                return NotFound();

            return View(painting);
        }

        // GET: Painting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Painting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Painting painting)
        {
            if (ModelState.IsValid)
            {
                _context.paintings.Add(painting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(painting);
        }

        // GET: Painting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var painting = await _context.paintings.FindAsync(id);

            if (painting == null)
                return NotFound();

            return View(painting);
        }

        // POST: Painting/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Painting painting)
        {
            if (id != painting.PaintingId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.paintings.Update(painting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaintingExists(painting.PaintingId))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(painting);
        }

        // GET: Painting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var painting = await _context.paintings
                .Include(p => p.Student)
                .Include(p => p.Competition)
                .FirstOrDefaultAsync(p => p.PaintingId == id);

            if (painting == null)
                return NotFound();

            return View(painting);
        }

        // POST: Painting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var painting = await _context.paintings.FindAsync(id);

            if (painting != null)
            {
                _context.paintings.Remove(painting);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PaintingExists(int id)
        {
            return _context.paintings.Any(e => e.PaintingId == id);
        }
    }
}