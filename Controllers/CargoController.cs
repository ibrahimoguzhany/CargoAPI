using AutoMapper;
using CargoAPI.DesignPatterns.SingletonPattern;
using CargoAPI.DTOModels;
using CargoAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CargoAPI.Controllers
{
    public class CargoController : ApiController
    {

        private NorthwindEntities _db;
        public CargoController()
        {
            _db = DBTool.DBInstance;
        }
        public IEnumerable<OrderDetailDTO> GetCargos()
        {
            return _db.Order_Details.ToList().Select(Mapper.Map<Order_Detail, OrderDetailDTO>);
        }

        public OrderDetailDTO GetCargo(int id)
        {
            var cargo = _db.Order_Details.FirstOrDefault(x => x.OrderID == id);

            if (cargo != null)
            {
                return Mapper.Map<Order_Detail, OrderDetailDTO>(cargo);
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);


        }

        [HttpPost]
        public OrderDetailDTO CreateCargo(OrderDetailDTO orderDetailDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cargo = Mapper.Map<OrderDetailDTO, Order_Detail>(orderDetailDTO);
            _db.Order_Details.Add(cargo);
            _db.SaveChanges();

            orderDetailDTO.CustomerID = cargo.; // cargo objesi veritabanina eklendikten sonra otomatik bir ID uretilir. onu client'teki ID'ye gondermeliyiz ki gorebilsin.

            return orderDetailDTO;
        }

        [HttpPut]
        public void UpdateCargo(int id, OrderDetailDTO orderDetailDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var orderDetailInDB = _db.Order_Details.FirstOrDefault(x => x.ID == id);

            if (orderDetailInDB != null)
            {

                Mapper.Map<OrderDetailDTO, Order_Detail>(orderDetailDTO, orderDetailInDB); //varolan bir obje varsa 2.bir arguman olarak buraya verebiliriz.

                //yukardaki satir sayesinde bu islem otomatik saglandi ve gerek kalmadi.
                //orderDetailInDB.TotalPrice = orderDetailDTO.TotalPrice;
                //orderDetailInDB.Quantity = orderDetailDTO.Quantity;
                //orderDetailInDB.Product.ProductName = orderDetailDTO.Product.ProductName;
                //orderDetailInDB.Shipper.CompanyName = orderDetailDTO.Shipper.CompanyName;
                //orderDetailInDB.Customer.Address= orderDetailDTO.Customer.Address;
                //orderDetailInDB.Customer.FirstName= orderDetailDTO.Customer.FirstName;
                //orderDetailInDB.Customer.LastName= orderDetailDTO.Customer.LastName;

                _db.SaveChanges();


            }
        }
    }
}

