using Microsoft.AspNetCore.Mvc;
using website_tim_viec_lam.Models;

namespace website_tim_viec_lam.Areas.Admin.Controllers
{
    public class TimKiem : Controller
    {
        //
        // GET: /TimKiem/
        public IActionResult KQTimKiem(string sTuKhoa)
        {
            //tìm kiếm theo tên sản phẩm
            var lstSP = new List<string>();
            return View();
        }
    }
}
