using Amazon_Tours.Utilities.ApiResponses.Factory;
using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using E_Invoicing.Application.DTOs.CreateDTOs;
using E_Invoicing.Application.DTOs.ReadDTOs;
using E_Invoicing.Application.Interfaces.Identity;
using E_Invoicing.Application.Utilities;
using E_Invoicing.Application.Utilities.HelperClasses;
using E_Invoicing.Application.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserDTO userDTO)
        {
            var myUser = HttpContext.User;

            if (!ModelState.IsValid)
            {
                var errorList = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                return BadRequest(ApiResponseFactory<IEnumerable<string>>.FailureResponse(errorList));
            }

            var registerResponse = await _userService.Register(userDTO);
            if (!string.IsNullOrEmpty(registerResponse.UserId))
            {
                return Ok(ApiResponseFactory<RegisterResponse>.SuccessResponse(registerResponse));
            }
            else
            {
                return BadRequest(ApiResponseFactory<RegisterResponse>.FailureResponse(registerResponse.Messages));
            }
        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var confirmEmailResponse = await _userService.ConfirmEmail(userId, token);
            if (confirmEmailResponse.IsSuccess)
            {
                return Ok(ApiResponseFactory<BoolWithListOfMessges>.SuccessResponse(confirmEmailResponse));
            }
            return BadRequest((ApiResponseFactory<BoolWithListOfMessges>.FailureResponse(confirmEmailResponse.Messages)));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var loginResponse = await _userService.Login(loginDTO);
            if (loginResponse.IsSuccess)
            {
                return Ok(ApiResponseFactory<LoginResponseDTO>.SuccessResponse(loginResponse));
            }
            else
            {
                return BadRequest(ApiResponseFactory<LoginResponseDTO>.FailureResponse(new List<string>() { loginResponse.Message }));
            }
        }

        [HttpPost("AddSystemRole")]
        public async Task<IActionResult> AddSystemRole(AddNewRoleDTO addSystemRoleDTO)
        {
            if (!ModelState.IsValid)
            {
                var errorList = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(ApiResponseFactory<IEnumerable<string>>.FailureResponse(errorList));
            }
            var response = await _userService.AddSystemRole(addSystemRoleDTO);
            if (response.IsSuccess)
            {
                return Ok(ApiResponseFactory<IEnumerable<string>>.SuccessResponse(response.Messages));
            }
            else
            {
                return BadRequest(ApiResponseFactory<IEnumerable<string>>.FailureResponse(response.Messages));
            }
        }

        [HttpGet("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            var result = await _userService.ForgetPassword(email);
            if (result.IsSuccess)
            {
                return Ok(ApiResponseFactory<BoolWithListOfMessges>.SuccessResponse(result));
            }
            else
            {
                return BadRequest(ApiResponseFactory<string>.FailureResponse(result.Messages));
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            if (!ModelState.IsValid)
            {
                var errorList = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(ApiResponseFactory<IEnumerable<string>>.FailureResponse(errorList));
            }
            var result = await _userService.ResetPassword(resetPasswordDTO);
            if (result.IsSuccess)
            {
                return Ok(ApiResponseFactory<BoolWithListOfMessges>.SuccessResponse(result));
            }
            else
            {
                return BadRequest(ApiResponseFactory<BoolWithListOfMessges>.FailureResponse(result.Messages));
            }
        }
    }
}
