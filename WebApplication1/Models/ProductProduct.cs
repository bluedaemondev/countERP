using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication1.Models
{
    public partial class ProductProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrdTemplateId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Active { get; set; }
        public virtual Currency currency { get; set; }
        public virtual ProductTemplate PrdTemplate { get; set; }
        public int Create_uid { get; set; }
        public int Write_uid { get; set; }
        public DateTime Write_date { get; set; }


    }
}
