using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(string email, string subject, string message);
        public Task<bool> SendEmailConfirmationAsync(string email, string token);
        public Task<bool> SendPasswordResetTokenAsync(string email, string token);
        public Task<bool> SendPasswordResetConfirmationAsync(string email);
    }
}
