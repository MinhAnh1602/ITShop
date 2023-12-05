using ITShop.Logic;
using ITShop.Models;
using Microsoft.AspNetCore.Mvc;
namespace ITShop.ViewComponents
{
    public class ChuDeViewComponent : ViewComponent
    {
        private readonly ITShopDbContext _context;

        public ChuDeViewComponent(ITShopDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ChuDe = _context.ChuDe.OrderBy(r => r.TenChuDe);
            return View("Default", ChuDe);
        }
    }
}

