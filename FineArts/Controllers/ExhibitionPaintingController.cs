//using FineArts.Areas.Identity.Data;
//using FineArts.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace FineArts.Controllers
//{
//    public class ExhibitionPaintingController : Controller
//    {
//        private readonly ApplicationDBContext _context;

//        public ExhibitionPaintingController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: ExhibitionPainting
//        public async Task<IActionResult> Index()
//        {
//            var exhibitionPaintings = await _context.exhibitionpaintings
//                .Include(e => e.Exhibition)
//                .Include(e => e.Painting)
//                .ToListAsync();

//            return View(exhibitionPaintings);
//        }

//        // GET: ExhibitionPainting/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var exhibitionPainting = await _context.exhibitionpaintings
//                .Include(e => e.Exhibition)
//                .Include(e => e.Painting)
//                .FirstOrDefaultAsync(m => m.ExhibitionPaintingId == id);

//            if (exhibitionPainting == null)
//                return NotFound();

//            return View(exhibitionPainting);
//        }

//        // GET: ExhibitionPainting/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: ExhibitionPainting/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(ExhibitionPainting exhibitionPainting)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.exhibitionpaintings.Add(exhibitionPainting);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(exhibitionPainting);
//        }

//        // GET: ExhibitionPainting/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var exhibitionPainting = await _context.exhibitionpaintings.FindAsync(id);

//            if (exhibitionPainting == null)
//                return NotFound();

//            return View(exhibitionPainting);
//        }

//        // POST: ExhibitionPainting/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, ExhibitionPainting exhibitionPainting)
//        {
//            if (id != exhibitionPainting.ExhibitionPaintingId)
//                return NotFound();

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.exhibitionpaintings.Update(exhibitionPainting);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ExhibitionPaintingExists(exhibitionPainting.ExhibitionPaintingId))
//                        return NotFound();

//                    throw;
//                }

//                return RedirectToAction(nameof(Index));
//            }

//            return View(exhibitionPainting);
//        }

//        // GET: ExhibitionPainting/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var exhibitionPainting = await _context.exhibitionpaintings
//                .Include(e => e.Exhibition)
//                .Include(e => e.Painting)
//                .FirstOrDefaultAsync(m => m.ExhibitionPaintingId == id);

//            if (exhibitionPainting == null)
//                return NotFound();

//            return View(exhibitionPainting);
//        }

//        // POST: ExhibitionPainting/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var exhibitionPainting = await _context.exhibitionpaintings.FindAsync(id);

//            if (exhibitionPainting != null)
//            {
//                _context.exhibitionpaintings.Remove(exhibitionPainting);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        private bool ExhibitionPaintingExists(int id)
//        {
//            return _context.exhibitionpaintings.Any(e => e.ExhibitionPaintingId == id);
//        }
//    }
//}