﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ProductProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrdTemplateId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Active { get; set; }

        public virtual ProductTemplate PrdTemplate { get; set; }
    }
}
