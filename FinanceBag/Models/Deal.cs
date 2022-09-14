using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage = "Поле <Дата/Время> пустое, заполните!!!")]
        [DisplayName("Дата/Время")]
        public DateTime DT { get; set; }

        [Required(ErrorMessage = "Поле <Кол-во> пустое, заполните!!!")]
        [DisplayName("Кол-во")]
        [Range(1,Int32.MaxValue, ErrorMessage = "Недопустимое значение")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Поле <Цена> пустое, заполните!!!")]
        [DisplayName("Цена")]
        [Range(0.00000001, double.MaxValue, ErrorMessage = "Недопустимое значение")]
        public decimal Price { get; set; }
        public decimal Sum { get; set; }

        [Required(ErrorMessage = "Поле <_ISIN_> пустое, заполните!!!")]
        [DisplayName("ISIN")]
        public string ISIN_id { get; set; }

        [ForeignKey("ISIN_id")]

        public Active Actives { get; set; }

    }
}
