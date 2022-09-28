
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinanceBag.Models
{
    public class Active
    {
        [Key]
        [Required(ErrorMessage = "Поле <_ISIN_> пустое, заполните!!!")]
        [DisplayName("ISIN")]
        public string ISIN_id { get; set; }

        [Required(ErrorMessage = "Поле <Тикер> пустое, заполните!!!")]
        [DisplayName("Тикер")]
        public string Ticker { get; set; }

        [Required(ErrorMessage = "Поле <Режим торгов> пустое, заполните!!!")]
        [DisplayName("Режим торгов")]
        public string TradingMode { get; set; }    
        public ICollection<Deal> Deals { get; set; }

        [Required(ErrorMessage = "Поле <Первичный ключ из таблицы <Тип Актива>> пустое, заполните!!!")]
        [DisplayName("Тип Актива")]
        public int TypeOfActive_id { get; set; }
        [ForeignKey("TypeOfActive_id")]
        public TypeOfActive TypeOfActive { get; set; }
    }
}
