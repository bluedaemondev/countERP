using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class AccountInvoice
    {
        public AccountInvoice()
        {
            AccountInvoiceLine = new HashSet<AccountInvoiceLine>();
            SoLineInvoiceRel = new HashSet<SoLineInvoiceRel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int OrderId { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual SaleOrder Order { get; set; }
        public virtual ICollection<AccountInvoiceLine> AccountInvoiceLine { get; set; }
        public virtual ICollection<SoLineInvoiceRel> SoLineInvoiceRel { get; set; }
    }
}
