using FineArts.Areas.Identity.Data;
using FineArts.Migrations;
using FineArts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FineArts.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment env;

        public CompetitionController(ApplicationDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Competition
        public async Task<IActionResult> Index()
        {
            var competitions = await _context.competitions
                .Include(c => c.Staff)
                .ToListAsync();

            return View(competitions);
        }

        // GET: Competition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var competition = await _context.competitions
                .Include(c => c.Staff)
                .FirstOrDefaultAsync(c => c.CompetitionId == id);

            if (competition == null)
                return NotFound();

            return View(competition);
        }

        // GET: Competition/Create
        public IActionResult Create()
        {
            string staffid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var staff = _context.staffs
                .FirstOrDefault(e => e.UserId == staffid);

            if (staff == null)
            {
                return NotFound();
            }

            ViewBag.staffid = staff.StaffId;

            ViewBag.CategoryId = new SelectList(_context.staffs, "Id");

            return View();
        }

        // POST: Competition/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(competitionimage competition)
        {


            if (ModelState.IsValid)
            {
                if (competition.path != null)
                {
                    string folder = Path.Combine(env.WebRootPath, "images");

                    string fileName = Guid.NewGuid().ToString() + "_" + competition.path.FileName;

                    string filepath = Path.Combine(folder, fileName);

                    competition.path.CopyTo(new FileStream(filepath, FileMode.Create));

                    Competition compdata = new Competition()
                    {
                        CompetitionTitle = competition.CompetitionTitle,
                        Description = competition.Description,
                        StartDate = competition.StartDate,
                        EndDate = competition.EndDate,
                        Conditions = competition.Conditions,
                        AwardDetails = competition.AwardDetails,
                        imageurl = "/images/" + fileName,
                        Staff_Id = competition.Staff_Id

                    };
                    _context.competitions.Add(compdata);
                    _context.SaveChanges();

                    return RedirectToAction("create");

                }
            }

            return View(competition);
        }
    }
}

        // GET: Competition/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var competition = await _context.competitions.FindAsync(id);

        //    if (competition == null)
        //        return NotFound();

        //    return View(competition);
        //}

        // POST: Competition/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Competition competition)
        //{
        //    if (id != competition.CompetitionId)
        //        return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(competition);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CompetitionExists(competition.CompetitionId))
        //                return NotFound();

        //            throw;
        //        }

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(competition);
        //}

        // GET: Competition/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var competition = await _context.competitions
//                .Include(c => c.Staff)
//                .FirstOrDefaultAsync(c => c.CompetitionId == id);

//            if (competition == null)
//                return NotFound();

//            return View(competition);
//        }

//        // POST: Competition/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var competition = await _context.competitions.FindAsync(id);

//            if (competition != null)
//            {
//                _context.competitions.Remove(competition);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        private bool CompetitionExists(int id)
//        {
//            return _context.competitions.Any(e => e.CompetitionId == id);
//        }
//    }
//}