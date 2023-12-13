﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using website_tim_viec_lam.Areas.Admin.Models;
using website_tim_viec_lam.Models;
using website_tim_viec_lam.Utilities;

namespace website_tim_viec_lam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index (AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            //Kiểm tra sự tồn tại của email trong CSDL
            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                //Hiển thị thông báo, có thể làm cách khác
                Functions._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }
            //Nếu không có thì thêm vào csdl
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}