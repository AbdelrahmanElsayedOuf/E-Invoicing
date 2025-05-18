using Models.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Reservation : IEntity
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }

        [ForeignKey(nameof(Trip))]
        public Guid TripId { get; set; }

        [ForeignKey(nameof(Hotel))]
        public Guid HotelId { get; set; }
        public DateTime Date { get; set; }
        public int NumOfAdults { get; set; }
        public int NumOfChildren { get; set; }
        public int NumOfSingleRooms { get; set; }
        public int NumOfDoubleRooms { get; set; }
        public int NumOfTripleRooms { get; set; }


        public Client Client { get; set; }
        public Hotel Hotel { get; set; }
        public Trip Trip { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [DefaultValue(true)]
        public bool IsInner { get; set; }
    }
}