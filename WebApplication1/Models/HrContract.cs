using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class HrContract
    {
        public HrContract()
        {
            HrContractEmployeeRel = new HashSet<HrContractEmployeeRel>();
            HrEmployee = new HashSet<HrEmployee>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? SueldoTotal { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<HrContractEmployeeRel> HrContractEmployeeRel { get; set; }
        public virtual ICollection<HrEmployee> HrEmployee { get; set; }
    }
}
