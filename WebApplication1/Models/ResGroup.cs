using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ResGroup
    {
        public ResGroup()
        {
            InverseResGroupParent = new HashSet<ResGroup>();
            ResGroupRuleRel = new HashSet<ResGroupRuleRel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ResGroupParentId { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ResGroup ResGroupParent { get; set; }
        public virtual ICollection<ResGroup> InverseResGroupParent { get; set; }
        public virtual ICollection<ResGroupRuleRel> ResGroupRuleRel { get; set; }
    }
}
