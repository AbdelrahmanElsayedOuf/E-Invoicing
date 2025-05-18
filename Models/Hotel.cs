using Models.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Hotel : IEntity
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(City))]
        public Guid CityId { get; set; }

        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }

        [Range(0, 8)]
        public int Rating { get; set; }

        public decimal DoubleRoomPrice { get; set; }

        public City City { get; set; } = new();
        public Country Country { get; set; } = new();
        public List<Reservation> Reservations { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [DefaultValue(true)]
        public bool IsInner { get; set; }
    }
}