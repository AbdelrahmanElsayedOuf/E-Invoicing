using Models.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Inquiry : IEntity
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(Trip))]
        public Guid TripId { get; set; }

        [EnumDataType(typeof(SeriousnessLevel))]
        public SeriousnessLevel SeriousnessLevel { get; set; }

        public Client Client { get; set; }
        public Trip Trip { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [DefaultValue(true)]
        public bool IsInner { get; set; }
    }
}
