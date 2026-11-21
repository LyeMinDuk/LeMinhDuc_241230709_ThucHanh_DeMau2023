using LeMinhDuc_241230709.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeMinhDuc_241230709.Components
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _db;
        public MenuLoaiViewComponent(QlhangHoaContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke() => View(_db.LoaiHangs.ToList());
    }
}
