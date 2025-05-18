using AmazonTours.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Services
{
    internal class EmailService : IEmailService
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public EmailService(IConfiguration configuration)
        {
            Email = configuration["EmailSettings:Email"];
            Password = configuration["EmailSettings:Password"];
            Host = configuration["EmailSettings:Host"];
            Port = int.Parse(configuration["EmailSettings:Port"]);
        }

        public Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendEmailConfirmationAsync(string email, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendPasswordResetConfirmationAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendPasswordResetTokenAsync(string email, string token)
        {
            throw new NotImplementedException();
        }
    }
}
