using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace pp.Controllers
{
    public class newsController : Controller
    {
        private readonly news_context _context;

        public newsController(news_context context)
        {
            _context = context;
        }

        // GET: news
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<news, categrory> news_context = _context.News.Include(n => n.categrory);
            return View(await news_context.ToListAsync());
        }

        // GET: news/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            news news = await _context.News
                .Include(n => n.categrory)
                .FirstOrDefaultAsync(m => m.Id == id);
            return news == null ? NotFound() : (IActionResult)View(news);
        }

        // GET: news/Create
        public IActionResult Create()
        {
            ViewData["categroryId"] = new SelectList(_context.categrories, "Id", "Name");
            return View();
        }

        // POST: news/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date,Image,Topic,categroryId")] news news)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(news);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categroryId"] = new SelectList(_context.categrories, "Id", "Name", news.categroryId);
            return View(news);
        }

        // GET: news/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            news news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["categroryId"] = new SelectList(_context.categrories, "Id", "Name", news.categroryId);
            return View(news);
        }

        // POST: news/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Image,Topic,categroryId")] news news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(news);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!newsExists(news.Id))
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
            ViewData["categroryId"] = new SelectList(_context.categrories, "Id", "Name", news.categroryId);
            return View(news);
        }

        // GET: news/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            news news = await _context.News
                .Include(n => n.categrory)
                .FirstOrDefaultAsync(m => m.Id == id);
            return news == null ? NotFound() : (IActionResult)View(news);
        }

        // POST: news/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            news news = await _context.News.FindAsync(id);
            _ = _context.News.Remove(news);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool newsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
