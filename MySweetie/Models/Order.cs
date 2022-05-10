using System;
using System.Collections.Generic;

#nullable disable

namespace MySweetie.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int Quantity { get; set; }
        public int InvoiceId { get; set; }

        public virtual Good Good { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
