using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pp.Models;
using System.Diagnostics;
using System.Linq;

namespace pp.Controllers
{
    public class HomeController : Controller
    {
        private readonly news_context _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(news_context context, ILogger<HomeController> logger)
        {
            _db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            System.Collections.Generic.List<categrory> result = _db.categrories.ToList();
            return View(result);
        }

        // Other action methods...
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Delete_News(int Id)
        {
            news news = _db.News.Find(Id);
            _ = _db.News.Remove(news);
            _ = _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult news(int id)
        {
            categrory c = _db.categrories.Find(id);
            //ViewBag.cat= c.Name;
            ViewData["name"] = c.Name;
            System.Collections.Generic.List<news> result = _db.News.Where(x => x.categroryId == id).OrderByDescending(z => z.Date).ToList();
            return View(result);
        }
        public IActionResult Team_Member()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save_Contact(contact_us model)
        {
            _ = _db.contact_Us.Add(model);
            _ = _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Contact_Response()
        {
            return View(_db.contact_Us.ToList());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult dotnet()
        {
            return View();
        }
        public IActionResult node()
        {
            return View();
        }
        public IActionResult react()
        {
            return View();
        }
        public IActionResult sql()
        {
            return View();
        }

    }




}
