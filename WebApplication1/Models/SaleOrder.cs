using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SaleOrder
    {
        public SaleOrder()
        {
            AccountInvoice = new HashSet<AccountInvoice>();
            SoLineInvoiceRel = new HashSet<SoLineInvoiceRel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int PaymentId { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual ICollection<AccountInvoice> AccountInvoice { get; set; }
        public virtual ICollection<SoLineInvoiceRel> SoLineInvoiceRel { get; set; }
    }
}
