using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using website_tim_viec_lam.Models;
using website_tim_viec_lam.Utilities;

namespace website_tim_viec_lam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;
        public MenuController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.Menus.OrderBy(m => m.MenuID).ToList();
            //Thêm 2 lệnh sau vào các Action của các controller để kiểm tra trạng thái đăng nhập
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(mnList);
        }
        public IActionResult Delete (int? id)
        {
            if (id == null || id == 0 )
            {
                return NotFound();
            }
            var mn = _context.Menus.Find(id);

            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete (int id)
        {
            var deleMenu = _context.Menus.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Menus.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----SELECT----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
        public IActionResult Edit (int? id)
        {
             if (id == null || id == 0)
            {
                return NotFound();
            }
             var mn = _context.Menus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----SELECT----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}