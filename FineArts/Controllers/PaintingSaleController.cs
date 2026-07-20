//using FineArts.Areas.Identity.Data;
//using FineArts.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace FineArts.Controllers
//{
//    public class PaintingSaleController : Controller
//    {
//        private readonly ApplicationDBContext _context;

//        public PaintingSaleController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: PaintingSale
//        public async Task<IActionResult> Index()
//        {
//            var paintingSales = await _context.paintingsales
//                .Include(p => p.ExhibitionPainting)
//                .Include(p => p.Customer)
//                .ToListAsync();

//            return View(paintingSales);
//        }

//        // GET: PaintingSale/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var paintingSale = await _context.paintingsales
//                .Include(p => p.ExhibitionPainting)
//                .Include(p => p.Customer)
//                .FirstOrDefaultAsync(m => m.PaintingSaleId == id);

//            if (paintingSale == null)
//            {
//                return NotFound();
//            }

//            return View(paintingSale);
//        }

//        // GET: PaintingSale/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: PaintingSale/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(PaintingSale paintingSale)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.paintingsales.Add(paintingSale);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(paintingSale);
//        }

//        // GET: PaintingSale/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var paintingSale = await _context.paintingsales.FindAsync(id);

//            if (paintingSale == null)
//            {
//                return NotFound();
//            }

//            return View(paintingSale);
//        }

//        // POST: PaintingSale/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, PaintingSale paintingSale)
//        {
//            if (id != paintingSale.PaintingSaleId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.paintingsales.Update(paintingSale);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PaintingSaleExists(paintingSale.PaintingSaleId))
//                    {
//                        return NotFound();
//                    }

//                    throw;
//                }

//                return RedirectToAction(nameof(Index));
//            }

//            return View(paintingSale);
//        }

//        // GET: PaintingSale/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var paintingSale = await _context.paintingsales
//                .Include(p => p.ExhibitionPainting)
//                .Include(p => p.Customer)
//                .FirstOrDefaultAsync(m => m.PaintingSaleId == id);

//            if (paintingSale == null)
//            {
//                return NotFound();
//            }

//            return View(paintingSale);
//        }

//        // POST: PaintingSale/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var paintingSale = await _context.paintingsales.FindAsync(id);

//            if (paintingSale != null)
//            {
//                _context.paintingsales.Remove(paintingSale);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        private bool PaintingSaleExists(int id)
//        {
//            return _context.paintingsales.Any(e => e.PaintingSaleId == id);
//        }
//    }
//}