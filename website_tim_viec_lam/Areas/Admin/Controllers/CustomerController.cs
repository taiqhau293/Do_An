using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using website_tim_viec_lam.Models;

namespace website_tim_viec_lam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly DataContext _context;
        public CustomerController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            // Tạo danh sách menu cho dropdown
            var mnList = _context.Customers
                .Select(m => new SelectListItem
                {
                    Text = m.FullName,
                    Value = m.CustomerID.ToString()
                })
                .ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer cus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cus);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cus);
        }
        public IActionResult Index()
        {
            var mnList = _context.Customers.OrderBy(m => m.CustomerID).ToList();
            return View(mnList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Customers.Find(id);

            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleCus = _context.Customers.Find(id);
            if (deleCus == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(deleCus);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Customers.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer mn)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}

