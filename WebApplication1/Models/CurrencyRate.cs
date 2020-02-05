using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CurrencyRate
    {
        /*private int id;
        private string date;
        private decimal ratio;
        private int create_uid;
        private int write_uid;
        private DateTime write_date;
        private DateTime create_date;
        */
        public int? Id { get; set; }
        public virtual Currency Currency { get; set; }
        public int Currency_id { get; set; }
        public string Date { get; set; }
        public decimal Ratio { get; set; }
        public bool? Active { get; set; }
        public int Create_uid { get; set; }
        public int Write_uid { get; set; }
        public DateTime Write_date { get; set; }
        public DateTime Create_date { get; set; }
    }
}