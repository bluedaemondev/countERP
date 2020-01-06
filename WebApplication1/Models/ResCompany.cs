using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ResCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vat { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string CState { get; set; }
        public string CCountry { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
