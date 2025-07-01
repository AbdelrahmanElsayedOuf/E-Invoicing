using Amazon_Tours.Utilities.ApiResponses.Factory;
using Amazon_Tours.Utilities.HelperClasses;
using E_Invoicing.Application.Interfaces.Services.Base;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Interfaces;
using System.Net;

namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController<T> : ControllerBase where T : class, IEntity, new()
    {
        private readonly IBaseService<T> _baseService;

        public AppBaseController()
        {
            
        }
        public AppBaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [NonAction]
        public IActionResult OkResponse<T>(T data, string message = null)
        {
            return Ok(ApiResponseFactory<T>.SuccessResponse(data, message));
        }

        [NonAction]
        public IActionResult BadRequestResponse(IEnumerable<string> messages)
        {
            return BadRequest(ApiResponseFactory<T>.FailureResponse(messages));
        }

        [NonAction]
        public IActionResult NotFoundResponse(string message = null)
        {
            return NotFound(ApiResponseFactory<T>.NotFoundResponse(message));
        }

        [NonAction]
        public IActionResult ErrorResponse(IEnumerable<string> messages)
        {
            return StatusCode(500, ApiResponseFactory<T>.ErrorResponse(messages));
        }

        [NonAction]
        protected async Task<EntityExistence> CheckExistedId(Guid id)
        {
            var entity = await _baseService.GetByIdAsync(id);
            return new EntityExistence()
            {
                Entity = entity,
                IsExisted = entity != null
            };
        }

        [NonAction]
        protected IActionResult InValidModelState()
        {
            var errorList = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            return BadRequestResponse(errorList);
        }
    }
}
