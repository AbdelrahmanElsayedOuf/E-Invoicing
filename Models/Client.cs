using Models.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : IEntity
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        public string FName { get; set; }
        [StringLength(100)]
        public string LName { get; set; }

        [StringLength(100)]
        public string? IdentityImage { get; set; }

        [ForeignKey(nameof(City))]
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CountdownEvent))]
        public Guid CountryId { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public List<Inquiry> Inquiries { get; set; }
        public List<Reservation> Reservations { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [DefaultValue(true)]
        public bool IsInner { get; set; }
    }
}
