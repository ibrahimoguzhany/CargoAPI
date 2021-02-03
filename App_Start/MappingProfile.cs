using AutoMapper;
using CargoAPI.DTOModels;
using CargoAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoAPI.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<Order_Detail, OrderDetailDTO>();
            Mapper.CreateMap<OrderDetailDTO, Order_Detail>();


        }
    }
}