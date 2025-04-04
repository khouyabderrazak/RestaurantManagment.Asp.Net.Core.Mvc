using AutoMapper;
using RestaurantManagement.DAL.Models;
using RestaurantManagement.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Restaurant, RestaurantModel>().ReverseMap();
        }
    }
}
