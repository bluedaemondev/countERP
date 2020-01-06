using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ResPartner
    {
        public ResPartner()
        {
            HrEmployee = new HashSet<HrEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Vat { get; set; }
        public string Street { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsProvider { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<HrEmployee> HrEmployee { get; set; }
    }
}
