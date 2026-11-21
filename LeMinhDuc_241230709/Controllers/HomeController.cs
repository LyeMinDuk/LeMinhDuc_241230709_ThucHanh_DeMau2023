using LeMinhDuc_241230709.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LeMinhDuc_241230709.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _db;
        public HomeController(QlhangHoaContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.TieuDe = "Lê Minh Đức";
            var ds = _db.HangHoas.Include(h => h.MaLoaiNavigation).
                Where(h => h.Gia >= 100).ToList();
            return View(ds);
        }

        public IActionResult TheoLoai(int id)
        {
            ViewBag.TieuDe = _db.LoaiHangs.Find(id)?.TenLoai;
            var ds = _db.HangHoas.Include(h => h.MaLoaiNavigation).
                Where(h => h.MaLoai == id).ToList();
            return PartialView("LeMinhDuc_MainContent", ds);
        }

        private void NapLoai(int? chon = null) => ViewBag.MaLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai", chon);

        public IActionResult Create()
        {
            NapLoai();
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa h)
        {
            if (!ModelState.IsValid)
            {
                NapLoai(h.MaLoai);
                return View(h);
            }
            _db.HangHoas.Add(h);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
