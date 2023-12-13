using Microsoft.EntityFrameworkCore;
using website_tim_viec_lam.Areas.Admin.Models;

namespace website_tim_viec_lam.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<view_Post_Menu> PostMenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}