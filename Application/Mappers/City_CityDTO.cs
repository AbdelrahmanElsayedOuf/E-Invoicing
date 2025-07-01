using E_Invoicing.Application.DTOs.ReadDTOs;
using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Mappers
{
    internal class City_CityDTO : Profile
    {
        public City_CityDTO()
        {
            CreateMap<City, CityDTO>();
        }
    }
}
