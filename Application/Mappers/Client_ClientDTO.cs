using AmazonTours.Application.DTOs.ReadDTOs;
using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Mappers
{
    public class Client_ClientDTO : Profile
    {
        public Client_ClientDTO()
        {
            CreateMap<Client, ClientDTO>()
                .ForMember(des => des.CityName, config => config.MapFrom(s => s.City.Name))
                .ForMember(des => des.CountryName, config => config.MapFrom(s => s.Country.Name));
            ;
        }
    }
}
