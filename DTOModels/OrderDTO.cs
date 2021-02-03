
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoAPI.DTOModels
{
    public class OrderDTO
    {
        public int OrderID { get; set; }

        public string ShippedAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public int? AppUserID { get; set; }
        public int? ShipperID { get; set; }


        //Sipariş işlemlerinin icerisindeki bilgileri daha rahat yakalamak adına actıgımız property'lerdir...
        public string UserName { get; set; }
        public string Email { get; set; }


        //Relational Properties

        public virtual AppUser AppUser { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
