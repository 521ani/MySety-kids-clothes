using System;
using System.Collections.Generic;

#nullable disable

namespace MySweetie.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TraderId { get; set; }

        public virtual Trader Trader { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
