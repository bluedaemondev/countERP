using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SoLineInvLineRel
    {
        public int Id { get; set; }
        public int SoLineId { get; set; }
        public int InvLineId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual AccountInvoiceLine InvLine { get; set; }
        public virtual SaleOrderLine SoLine { get; set; }
    }
}
