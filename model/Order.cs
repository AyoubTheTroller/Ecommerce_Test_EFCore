using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}