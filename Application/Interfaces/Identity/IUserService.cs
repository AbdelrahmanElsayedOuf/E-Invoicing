using E_Invoicing.Application.DTOs.CreateDTOs;
using E_Invoicing.Application.DTOs.ReadDTOs;
using E_Invoicing.Application.Interfaces.Services.Base;
using E_Invoicing.Application.Utilities.HelperClasses;
using E_Invoicing.Application.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Interfaces.Identity
{
    public interface IUserService
    {
        Task<RegisterResponse> Register(CreateUserDTO userDTO);
        Task<BoolWithListOfMessges> ConfirmEmail(string userId, string token);
        Task<LoginResponseDTO> Login(LoginDTO loginDTO);
        Task<BoolWithListOfMessges> AddSystemRole(AddNewRoleDTO addSystemRoleDTO);
        Task<BoolWithListOfMessges> ForgetPassword(string email);
        Task<BoolWithListOfMessges> ResetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}
