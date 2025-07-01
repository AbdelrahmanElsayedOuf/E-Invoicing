using E_Invoicing.Application.DTOs.ReadDTOs;
using E_Invoicing.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Mappers
{
    public class RecieptVoucher_RecieptVoucherDTO : Profile
    {
        public RecieptVoucher_RecieptVoucherDTO()
        {
            CreateMap<RecieptVoucher, RecieptVoucherDTO>()
                .ForMember(des => des.ClientName, config => config.MapFrom(s => s.Client.FName))
                .ForMember(des => des.EmployeeName, config => config.MapFrom(s => s.Employee.UserName))       
                ;
        }
    }
}
