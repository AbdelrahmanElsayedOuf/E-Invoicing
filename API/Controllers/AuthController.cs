using Amazon_Tours.Utilities.ApiResponses.Factory;
using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.DTOs.ReadDTOs;
using AmazonTours.Application.Interfaces.Identity;
using AmazonTours.Application.Utilities;
using AmazonTours.Application.Utilities.HelperClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

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
    }
}
