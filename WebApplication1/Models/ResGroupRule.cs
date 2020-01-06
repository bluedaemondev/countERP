using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ResGroupRule
    {
        public ResGroupRule()
        {
            ResGroupRuleRel = new HashSet<ResGroupRuleRel>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Arch { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<ResGroupRuleRel> ResGroupRuleRel { get; set; }
    }
}
