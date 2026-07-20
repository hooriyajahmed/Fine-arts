//using FineArts.Areas.Identity.Data;
//using FineArts.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace FineArts.Controllers
//{
//    public class ExhibitionController : Controller
//    {
//        private readonly ApplicationDBContext _context;

//        public ExhibitionController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: Exhibition
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.exhibitions.ToListAsync());
//        }

//        // GET: Exhibition/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var exhibition = await _context.exhibitions
//                .FirstOrDefaultAsync(m => m.ExhibitionId == id);

//            if (exhibition == null)
//            {
//                return NotFound();
//            }

//            return View(exhibition);
//        }

//        // GET: Exhibition/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Exhibition/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Exhibition exhibition)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(exhibition);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(exhibition);
//        }

//        // GET: Exhibition/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var exhibition = await _context.exhibitions.FindAsync(id);

//            if (exhibition == null)
//            {
//                return NotFound();
//            }

//            return View(exhibition);
//        }

//        // POST: Exhibition/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Exhibition exhibition)
//        {
//            if (id != exhibition.ExhibitionId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(exhibition);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ExhibitionExists(exhibition.ExhibitionId))
//                    {
//                        return NotFound();
//                    }

//                    throw;
//                }

//                return RedirectToAction(nameof(Index));
//            }

//            return View(exhibition);
//        }

//        // GET: Exhibition/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var exhibition = await _context.exhibitions
//                .FirstOrDefaultAsync(m => m.ExhibitionId == id);

//            if (exhibition == null)
//            {
//                return NotFound();
//            }

//            return View(exhibition);
//        }

//        // POST: Exhibition/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var exhibition = await _context.exhibitions.FindAsync(id);

//            if (exhibition != null)
//            {
//                _context.exhibitions.Remove(exhibition);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        private bool ExhibitionExists(int id)
//        {
//            return _context.exhibitions.Any(e => e.ExhibitionId == id);
//        }
//    }
//}