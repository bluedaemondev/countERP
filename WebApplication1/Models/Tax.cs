using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Tax
    {
        public Tax()
        {
            AccountInvoiceLine = new HashSet<AccountInvoiceLine>();
            SaleOrderLine = new HashSet<SaleOrderLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayDescr { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<AccountInvoiceLine> AccountInvoiceLine { get; set; }
        public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }
    }
}
