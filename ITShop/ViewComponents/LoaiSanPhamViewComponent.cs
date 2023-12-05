using ITShop.Logic;
using ITShop.Models;
using Microsoft.AspNetCore.Mvc;
namespace ITShop.ViewComponents
{
    public class LoaiSanPhamViewComponent : ViewComponent
    {
        private readonly ITShopDbContext _context;

        public LoaiSanPhamViewComponent(ITShopDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var LoaiSanPham = _context.LoaiSanPham.OrderBy(r => r.TenLoai);
            return View("Default",LoaiSanPham);
        }
    }
}

