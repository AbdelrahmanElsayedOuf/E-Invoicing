using E_Invoicing.Domain.Enums;
using Models.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Trip : IEntity
    {
        public Guid Id { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        [EnumDataType(typeof(FoodMeals))]
        public FoodMeals FoodMeals { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }

        [ForeignKey(nameof(City))]
        public Guid CityId { get; set; }
        public int NumOfDays { get; set; }
        public int NumOfNights { get; set; }

        [ForeignKey(nameof(Hotel))]
        public Guid HotelId { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public Hotel Hotel { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Inquiry> Inquiries { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [DefaultValue(true)]
        public bool IsInner { get; set; }
    }
}
