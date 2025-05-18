using AmazonTours.Application.Utilities.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.DTOs.ReadDTOs
{
    public class RegisterResponse
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
