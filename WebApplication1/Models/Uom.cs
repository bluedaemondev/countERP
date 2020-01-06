using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Uom
    {
        public Uom()
        {
            ProductTemplate = new HashSet<ProductTemplate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }
    }
}
