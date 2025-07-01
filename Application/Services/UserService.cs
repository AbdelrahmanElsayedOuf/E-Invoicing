using E_Invoicing.Application.DTOs.CreateDTOs;
using E_Invoicing.Application.DTOs.ReadDTOs;
using E_Invoicing.Application.Interfaces.Identity;
using E_Invoicing.Application.Utilities.HelperClasses;
using E_Invoicing.Application.DTOs.Auth;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static E_Invoicing.Application.Utilities.HelperClasses.Enums;
using E_Invoicing.Application.Interfaces.JWT;

namespace E_Invoicing.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly IFluentEmail _fluentEmail;
        private readonly IConfiguration _configurationManager;

        public UserService(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtService jwtService,
            IFluentEmail fluentEmail, 
            IConfiguration configurationManager)
        {
            _userManager = userManager;
            _fluentEmail = fluentEmail;
            _jwtService = jwtService;
            _configurationManager = configurationManager;
            _roleManager = roleManager;
        }

        public async Task<RegisterResponse> Register(CreateUserDTO userDTO)
        {
            var registerResponse = new RegisterResponse();

            try
            {
                var existingUser = await _userManager.FindByEmailAsync(userDTO.Email);
                if (existingUser != null)
                {
                    registerResponse.IsEmailConfirmed = existingUser.EmailConfirmed;
                    registerResponse.Messages = new List<string>() { "Email is already registered before." } ;
                    return registerResponse;
                }

                var user = new IdentityUser
                {
                    Email = userDTO.Email,
                    UserName = userDTO.Email.Split('@').First(),
                };

                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, UserRole.USER.ToString());
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var baseUrl = _configurationManager["AppSettings:ConfirmationLinkBaseUrl"];
                    var confirmationLink = $"{baseUrl}?userId={user.Id}&token={Uri.EscapeDataString(token)}";

                    string emailBody = $@"
<html>
<head>
  <style>
    .button {{
      background-color: #4CAF50;
      border: none;
      color: white;
      padding: 12px 24px;
      text-align: center;
      text-decoration: none;
      display: inline-block;
      font-size: 16px;
      margin: 10px 0;
      cursor: pointer;
      border-radius: 6px;
    }}
  </style>
</head>
<body>
  <p>Hello {System.Net.WebUtility.HtmlEncode(user.UserName)},</p>
  <p>Please confirm your email by clicking the button below:</p>
  <a href=""{confirmationLink}"" class=""button"">Confirm Email</a>
  <p>If you did not request this, please ignore this email.</p>
</body>
</html>
";

                    await _fluentEmail
                        .To(user.Email)
                        .Subject("Confirm your email")
                        .Body(emailBody, isHtml: true)
                        .SendAsync();



                    registerResponse.UserId = user.Id;
                    registerResponse.Messages = new List<string>() { "User created successfully! Please check your email to confirm your account." };
                    registerResponse.Roles = new List<string>() { UserRole.USER.ToString() };
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
            var confirmResponse = new BoolWithListOfMessges()
            {
                Messages = new List<string>()
            };
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

        public async Task<LoginResponseDTO> Login(LoginDTO loginDTO)
        {
            var loginResponse = new LoginResponseDTO();

            try
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (user == null)
                {
                    // Simulate a password check to avoid timing attacks
                    var simulationaIsPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
                    loginResponse.IsSuccess = false;
                    loginResponse.Message = "User or Password is not correct";
                    return loginResponse;
                }

                var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
                if (!isPasswordValid)
                {
                    loginResponse.IsSuccess = false;
                    loginResponse.Message = "User or Password is not correct";
                    return loginResponse;
                }

                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    loginResponse.IsSuccess = false;
                    loginResponse.Message = "Email not confirmed yet, please check your mail";
                    return loginResponse;
                }

                var roles = (await _userManager.GetRolesAsync(user)).ToList();
                loginResponse.User = new UserInfoDto
                {
                    Id = user.Id,
                    Email = user.Email ?? string.Empty,
                    Roles = roles
                };

                var token = _jwtService.GenerateToken(user, roles);
                loginResponse.Token = token.ToString();
                loginResponse.IsSuccess = true;
                loginResponse.Message = "Successful Login";
            }
            catch (Exception)
            {
                loginResponse.IsSuccess = false;
                loginResponse.Message = "An Error Occurred";
            }

            return loginResponse;
        }

        public async Task<BoolWithListOfMessges> AddSystemRole(AddNewRoleDTO addSystemRoleDTO)
        {
            var response = new BoolWithListOfMessges
            {
                Messages = new List<string>()
            };

            try
            {
                var normalizedRole = addSystemRoleDTO.Role.ToUpperInvariant();
                var existedRole = await _roleManager.FindByNameAsync(normalizedRole);

                if (existedRole != null)
                {
                    response.IsSuccess = false;
                    ((List<string>)response.Messages).Add("Role already exists.");
                    return response;
                }

                var addRoleResult = await _roleManager.CreateAsync(new IdentityRole(normalizedRole));
                if (addRoleResult.Succeeded)
                {
                    response.IsSuccess = true;
                    ((List<string>)response.Messages).Add("Role added successfully.");
                }
                else
                {
                    response.IsSuccess = false;
                    response.Messages = addRoleResult.Errors.Select(e => e.Description).ToList();
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                ((List<string>)response.Messages).Add("An unexpected error occurred while adding the role. " + ex.Message);
            }

            return response;
        }

    }
}
