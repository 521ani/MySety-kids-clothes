using System;
using System.Collections.Generic;

#nullable disable

namespace MySweetie.Models
{
    public partial class Material
    {
        public Material()
        {
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string Material1 { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
