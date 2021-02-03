
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoAPI.DTOModels
{
    public class ShipperDTO
    {
        public int ShipperID { get; set; }

        public string CompanyName { get; set; }
        public string Phone { get; set; }

        //Relational Properties
        public virtual List<Order> Orders { get; set; }
    }
}
