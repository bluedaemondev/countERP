using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SoLineInvoiceRel
    {
        public int Id { get; set; }
        public int SoId { get; set; }
        public int InvId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual AccountInvoice Inv { get; set; }
        public virtual SaleOrder So { get; set; }
    }
}
