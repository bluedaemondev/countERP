using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class HrEmployee
    {
        public HrEmployee()
        {
            HrContractEmployeeRel = new HashSet<HrContractEmployeeRel>();
            ResUser = new HashSet<ResUser>();
        }

        public int Id { get; set; }
        public int PartnerId { get; set; }
        public int? ContractId { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual HrContract Contract { get; set; }
        public virtual ResPartner Partner { get; set; }
        public virtual ICollection<HrContractEmployeeRel> HrContractEmployeeRel { get; set; }
        public virtual ICollection<ResUser> ResUser { get; set; }
    }
}
