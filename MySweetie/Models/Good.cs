using System;
using System.Collections.Generic;

#nullable disable

namespace MySweetie.Models
{
    public partial class Good
    {
        public Good()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MaterialId { get; set; }
        public decimal RetailPrice { get; set; }

        public virtual Material Material { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
