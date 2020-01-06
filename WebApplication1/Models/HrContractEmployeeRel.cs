using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class HrContractEmployeeRel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual HrContract Contract { get; set; }
        public virtual HrEmployee Employee { get; set; }
    }
}
