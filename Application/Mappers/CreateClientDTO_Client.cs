using AmazonTours.Application.DTOs.CreateDTOs;
using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Mappers
{
    public class CreateClientDTO_Client : Profile
    {
        public CreateClientDTO_Client()
        {
            CreateMap<CreateClientDTO, Client>();
        }
    }
}
