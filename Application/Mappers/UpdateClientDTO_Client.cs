using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.DTOs.UpdateDTOs;
using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Mappers
{
    public class UpdateClientDTO_Client : Profile
    {
        public UpdateClientDTO_Client()
        {
            CreateMap<UpdateClientDTO, Client>();
        }
    }
}
