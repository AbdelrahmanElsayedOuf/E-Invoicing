using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Utilities.HelperClasses
{
    public class BoolWithSingleMessge
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class BoolWithListOfMessges
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
