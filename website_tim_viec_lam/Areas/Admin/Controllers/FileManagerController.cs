using Microsoft.AspNetCore.Mvc;
using website_tim_viec_lam.Utilities;

namespace website_tim_viec_lam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/file-manager/Index")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            //Thêm 2 lệnh sau vào các Action của các controller để kiểm tra trạng thái đăng nhập
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
    }
}
