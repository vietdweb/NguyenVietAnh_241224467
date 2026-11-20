using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenVietAnh_241224467.Models;
using System.Diagnostics;

namespace NguyenVietAnh_241224467.Controllers
{
    public class HomeController : Controller
    {
        QlnhaSachContext db;
        public HomeController(QlnhaSachContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var saches = db.Saches.Where(s => s.Gia >= 100).ToList();
            return View(saches);
        }
        public IActionResult SachTheoLoai(int matl)
        {
            var saches = db.Saches.Where(s => s.MaTl == matl).ToList();
            return PartialView("SachTheoLoai", saches);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(db.TheLoais, "MaTl", "TenTl");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            ModelState.Remove("MaTlNavigation");
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTl = new SelectList(db.TheLoais, "MaTl", "TenTl");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
