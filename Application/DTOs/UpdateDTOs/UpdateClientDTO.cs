using AmazonTours.Application.DTOs.Interfaces;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.DTOs.UpdateDTOs
{
    public class UpdateClientDTO : IDTO
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Gender Gender { get; set; }
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
    }
}
