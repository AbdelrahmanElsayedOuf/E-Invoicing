using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.DTOs.ReadDTOs;
using AmazonTours.Application.Interfaces.Identity;
using AmazonTours.Application.Utilities.HelperClasses;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IFluentEmail _fluentEmail;

        public UserService(UserManager<IdentityUser> userManager, IFluentEmail fluentEmail)
        {
            _userManager = userManager;
            _fluentEmail = fluentEmail;
        }

        public async Task<RegisterResponse> Register(CreateUserDTO userDTO)
        {
            var registerResponse = new RegisterResponse();

            try
            {
                // Check if the email is already registered
                var existingUser = await _userManager.FindByEmailAsync(userDTO.Email);
                if (existingUser != null)
                {
                    registerResponse.IsEmailConfirmed = existingUser.EmailConfirmed;
                    registerResponse.Messages = new List<string>() { "Email is already registered before." } ;
                    return registerResponse;
                }

                // Create a new IdentityUser
                var user = new IdentityUser
                {
                    Email = userDTO.Email,
                    UserName = userDTO.Email.Split('@').First(), // Use the part before '@' as username
                };

                // Create the user in the database
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (result.Succeeded)
                {
                    // Generate email confirmation token
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    // Create confirmation link (replace "your-app-url" with your actual app URL)
                    var confirmationLink = $"https://your-app-url/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

                    // TODO: Send the confirmation link via email (integrate an email service)
                    await _fluentEmail
                        .To(user.Email)
                        .Subject("Confirm your email")
                        .Body($"Please confirm your email by clicking this link: {confirmationLink}")
                        .SendAsync();


                    registerResponse.UserId = user.Id;
                    registerResponse.Messages = new List<string>() { "User created successfully! Please check your email to confirm your account." };
                }
                else
                {
                    // Handle errors during user creation
                    registerResponse.Messages = result.Errors.Select(e => e.Description);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework like Serilog, NLog, etc.)
                // Example: _logger.LogError(ex, "An error occurred during user registration.");
                registerResponse.Messages = new List<string>() { "An unexpected error occurred. Please try again later." };
            }

            return registerResponse;
        }

        public async Task<BoolWithListOfMessges> ConfirmEmail(string userId, string token)
        {
            var confirmResponse = new BoolWithListOfMessges();
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    confirmResponse.IsSuccess = false;
                    confirmResponse.Messages.Append("User not found.");
                    return confirmResponse;
                }
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    confirmResponse.IsSuccess = true;
                    confirmResponse.Messages.Append("Email confirmed successfully!");
                }
                else
                {
                    confirmResponse.IsSuccess = false;
                    foreach (var error in result.Errors)
                    {
                        confirmResponse.Messages.Append(string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework like Serilog, NLog, etc.)
                // Example: _logger.LogError(ex, "An error occurred during email confirmation.");
                confirmResponse.IsSuccess = false;
                confirmResponse.Messages.Append("An unexpected error occurred. Please try again later.");
            }
            return confirmResponse;
        }

    }
}
