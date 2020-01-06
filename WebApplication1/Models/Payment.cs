using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Payment
    {
        public Payment()
        {
            SaleOrder = new HashSet<SaleOrder>();
        }

        public int Id { get; set; }
        public string PaymentDescr { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountDiscount { get; set; }
        public bool? IsCheck { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<SaleOrder> SaleOrder { get; set; }
    }
}
