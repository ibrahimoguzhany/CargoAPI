
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoAPI.DTOModels
{
    public class CategoryDTO
    {
        //todo:DTO sınıflarınızı acın, ilişkileri almayın sadece ID,name,description gibi anlamlı bilgileri alın

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Relational Properties
        public virtual List<Product> Products { get; set; }

        public CategoryDTO()
        {
            Products = new List<Product>();
        }

    }
}
