
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoAPI.DTOModels
{
    public class OrderDetailDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int ShipperID { get; set; }
        public int CustomerID { get; set; }

        public decimal TotalPrice { get; set; }
        public short Quantity { get; set; }


        //Relational Properties
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual UserProfile Customer { get; set; }



    }
}
