using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Interfaces.JWT
{
    public interface IJwtService
    {
        public string GenerateToken(IdentityUser user, List<string> roles);
    }
}
