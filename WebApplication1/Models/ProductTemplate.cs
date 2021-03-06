﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ProductTemplate
    {
        public ProductTemplate()
        {
            ProductProduct = new HashSet<ProductProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public int? UomId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Active { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Uom Uom { get; set; }
        public virtual ICollection<ProductProduct> ProductProduct { get; set; }
    }
}
