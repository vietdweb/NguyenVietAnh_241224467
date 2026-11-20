using Microsoft.AspNetCore.Mvc;
using NguyenVietAnh_241224467.Models;
namespace NguyenVietAnh_241224467.ViewComponents
{
    public class TheLoaiViewComponent:ViewComponent
    {
        QlnhaSachContext db;
        List<TheLoai> theLoais;
        public TheLoaiViewComponent(QlnhaSachContext context)
        {
            db = context;
            theLoais = db.TheLoais.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderTheLoai", theLoais);
        }
    }
}
