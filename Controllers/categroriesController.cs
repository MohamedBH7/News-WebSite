using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace pp.Controllers
{
    public class categroriesController : Controller
    {
        private readonly news_context _db;

        public categroriesController(news_context context)
        {
            _db = context;
        }

        // GET: categrories
        public IActionResult Index()
        {
            return View(_db.categrories.ToList());
        }

        // GET: categrories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            categrory categrory = await _db.categrories
                .FirstOrDefaultAsync(m => m.Id == id);
            return categrory == null ? NotFound() : (IActionResult)View(categrory);
        }

        // GET: categrories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: categrories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type")] categrory categrory)
        {
            if (ModelState.IsValid)
            {
                _ = _db.Add(categrory);
                _ = await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categrory);
        }

        // GET: categrories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            categrory categrory = await _db.categrories.FindAsync(id);
            return categrory == null ? NotFound() : (IActionResult)View(categrory);
        }

        // POST: categrories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type")] categrory categrory)
        {
            if (id != categrory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _db.Update(categrory);
                    _ = await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categroryExists(categrory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categrory);
        }

        // GET: categrories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            categrory categrory = await _db.categrories
                .FirstOrDefaultAsync(m => m.Id == id);
            return categrory == null ? NotFound() : (IActionResult)View(categrory);
        }

        // POST: categrories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            categrory categrory = await _db.categrories.FindAsync(id);
            _ = _db.categrories.Remove(categrory);
            _ = await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool categroryExists(int id)
        {
            return _db.categrories.Any(e => e.Id == id);
        }
    }
}
