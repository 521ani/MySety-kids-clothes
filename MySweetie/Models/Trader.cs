using System;
using System.Collections.Generic;

#nullable disable

namespace MySweetie.Models
{
    public partial class Trader
    {
        public Trader()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Tel { get; set; }
        public long TaxNumber { get; set; }
        public string Mol { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
