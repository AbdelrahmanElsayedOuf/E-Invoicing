using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.DTOs.Auth
{
    public class LoginResponseDTO
    {
        public bool IsSuccess { get; set; }
        public UserInfoDto User { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
