
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinanceBag.Models
{
    public class Active
    {
        [Key]
        public string ISIN_id { get; set; }
        public string Ticker { get; set; }
        public ICollection<Deal> Deals { get; set; }

        public int TypeOfActive_id { get; set; }
        [ForeignKey("TypeOfActive_id")]
        public TypeOfActive TypeOfActive { get; set; }
    }
}
