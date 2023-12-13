using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace website_tim_viec_lam.Models
{
    [Table("Customer")]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int Phone {  get; set; }
        public int CCCD { get; set; }
        public string? Address { get; set; }
    }
}
