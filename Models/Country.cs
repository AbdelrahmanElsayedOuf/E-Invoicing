using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Country : IEntity
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public List<Client> Clients { get; set; }
        public List<City> Cities { get; set; }
        public List<Trip> Trips { get; set; }
        public List<Hotel> Hotels { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [DefaultValue(true)]
        public bool IsInner { get; set; }
    }
}
