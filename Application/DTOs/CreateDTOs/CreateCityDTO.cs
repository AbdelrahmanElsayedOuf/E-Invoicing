using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.DTOs.CreateDTOs
{
    public class CreateCityDTO
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
    }
}
