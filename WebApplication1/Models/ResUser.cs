﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ResUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual HrEmployee Employee { get; set; }
    }
}
