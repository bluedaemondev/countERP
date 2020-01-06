using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ResGroupRuleRel
    {
        public int Id { get; set; }
        public int ResGroupId { get; set; }
        public int ResRuleId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ResGroup ResGroup { get; set; }
        public virtual ResGroupRule ResRule { get; set; }
    }
}
