using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsInner { get; set; }
    }
}
