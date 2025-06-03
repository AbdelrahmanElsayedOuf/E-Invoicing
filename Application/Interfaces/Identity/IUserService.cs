using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.DTOs.ReadDTOs;
using AmazonTours.Application.Interfaces.Services.Base;
using AmazonTours.Application.Utilities.HelperClasses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Interfaces.Identity
{
    public interface IUserService
    {
        Task<RegisterResponse> Register(CreateUserDTO userDTO);
        Task<BoolWithListOfMessges> ConfirmEmail(string userId, string token);

    }
}
