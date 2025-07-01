using E_Invoicing.Application.DTOs.Interfaces;
using AutoMapper;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Utilities.Extensions
{
    public static class DTOExtension
    {
        public static T ToEntity<T>(this IDTO dto, IMapper mapper)
        {
            return mapper.Map<T>(dto);
        }

        public static IEnumerable<T> ToEntityCollection<T>(this IEnumerable<IDTO> dtos, IMapper mapper)
        {
            return dtos.Select(dto => mapper.Map<T>(dto));
        }
    }
}
