using Models.Enums;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonTours.Application.DTOs.Interfaces;

namespace AmazonTours.Application.DTOs.CreateDTOs
{
    public class CreateClientDTO : IDTO
    {
        [Required]
        [StringLength(100)]
        public string FName { get; set; }
        public string LName { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        public Guid? CityId { get; set; }
        [Required]
        public Guid? CountryId { get; set; }
    }
}
