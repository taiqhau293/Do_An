using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using website_tim_viec_lam.Utilities;

namespace website_tim_viec_lam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Thêm 2 lệnh sau vào các Action của các controller để kiểm tra trạng thái đăng nhập
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
        public IActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._UserName = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}
