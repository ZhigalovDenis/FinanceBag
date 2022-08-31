using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceBag.Models
{
    
    public class TypeOfActive
    {
        [Key]
        public int TypeOfActive_id { get; set; }

        [Required(ErrorMessage = "Поле <Тип актива> пустое, заполните!!!")]
        [DisplayName("Тип актива")]
        public string Type { get; set; }


        public  ICollection<Active> Actives { get; set; }
    }
}
