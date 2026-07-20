//using FineArts.Areas.Identity.Data;
//using FineArts.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace FineArts.Controllers
//{
//    public class CustomerController : Controller
//    {
//        private readonly ApplicationDBContext _context;

//        public CustomerController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: Customer
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.customers.ToListAsync());
//        }

//        // GET: Customer/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer = await _context.customers
//                .FirstOrDefaultAsync(m => m.CustomerId == id);

//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return View(customer);
//        }

//        // GET: Customer/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Customer/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Customer customer)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.customers.Add(customer);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(customer);
//        }

//        // GET: Customer/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer = await _context.customers.FindAsync(id);

//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return View(customer);
//        }

//        // POST: Customer/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Customer customer)
//        {
//            if (id != customer.CustomerId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.customers.Update(customer);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CustomerExists(customer.CustomerId))
//                    {
//                        return NotFound();
//                    }

//                    throw;
//                }

//                return RedirectToAction(nameof(Index));
//            }

//            return View(customer);
//        }

//        // GET: Customer/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer = await _context.customers
//                .FirstOrDefaultAsync(m => m.CustomerId == id);

//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return View(customer);
//        }

//        // POST: Customer/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var customer = await _context.customers.FindAsync(id);

//            if (customer != null)
//            {
//                _context.customers.Remove(customer);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        private bool CustomerExists(int id)
//        {
//            return _context.customers.Any(e => e.CustomerId == id);
//        }
//    }
//}