using Microsoft.AspNetCore.Mvc;
using website_tim_viec_lam.Models;

namespace website_tim_viec_lam.Areas.Admin.Components
{
    [ViewComponent(Name ="AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private readonly DataContext _context;
        public AdminMenuComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnList = (from mn in _context.AdminMenus
                          where(mn.IsActive == true)
                          select mn).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", mnList));
        }
    }
}
