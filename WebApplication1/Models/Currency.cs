using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Ratios = new HashSet<CurrencyRate>();
        }
        
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public string Code { get; set; }
        public virtual ICollection<CurrencyRate> Ratios { get; set; }
        public int Create_uid { get; set; }
        public int Write_uid { get; set; }
        public DateTime Write_date { get; set; }
        public DateTime Create_date { get; set; }
    }
}
