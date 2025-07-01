using E_Invoicing.Application.DTOs.CreateDTOs;
using E_Invoicing.Application.DTOs.UpdateDTOs;
using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Mappers
{
    public class UpdateClientDTO_Client : Profile
    {
        public UpdateClientDTO_Client()
        {
            CreateMap<UpdateClientDTO, Client>();
        }
    }
}
