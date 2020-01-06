using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SaleOrderLine
    {
        public SaleOrderLine()
        {
            SoLineInvLineRel = new HashSet<SoLineInvLineRel>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public decimal? AmountUntaxed { get; set; }
        public decimal? AmountTax { get; set; }
        public decimal? AmountTotal { get; set; }
        public int? TaxId { get; set; }
        public bool? Active { get; set; }
        public bool? Invoiced { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Tax Tax { get; set; }
        public virtual ICollection<SoLineInvLineRel> SoLineInvLineRel { get; set; }
    }
}
