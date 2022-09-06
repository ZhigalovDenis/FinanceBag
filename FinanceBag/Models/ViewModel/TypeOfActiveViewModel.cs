using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinanceBag.Models.ViewModel
{
	public class TypeOfActiveViewModel
	{
        public int TypeOfActive_id { get; set; }


        [Required(ErrorMessage = "Поле <Тип актива> пустое, заполните!!!")]
        [DisplayName("Тип актива")]
        public string Type { get; set; }

    }
}
