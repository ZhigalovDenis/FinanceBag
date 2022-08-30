using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceBag.Models
{
    public class Deal
    {
        [Key]
        public int Deal_id { get; set; }
        public DateTime DT { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Sum { get; set; }

        public string ISIN_id { get; set; }
        [ForeignKey("ISIN_id")]

        public Active Actives { get; set; }

    }
}
