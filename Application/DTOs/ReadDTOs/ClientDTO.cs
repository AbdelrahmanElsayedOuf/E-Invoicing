using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.DTOs.ReadDTOs
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Gender Gender { get; set; }
        public string CityName {  get; set; }
        public string CountryName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }

    }
}
