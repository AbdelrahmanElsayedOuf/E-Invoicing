using Amazon_Tours.Utilities.ApiResponses.Factory;
using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using AmazonTours.Application.DTOs.ReadDTOs;
using AmazonTours.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;

namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /*private readonly ICityService _cityService;

        public TestController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("GetAllCities")]
        public async Task<IApiResponse<List<CityDTO>>> GetAllCities()
        {
            var allCities = await _cityService.GetAllAsync(city => city.Country);
            var allCitiesDtos = new List<CityDTO>();
            foreach (var item in allCities)
            {
                allCitiesDtos.Add(
                new CityDTO()
                {
                    Id = item.Id,
                    CountryName = item.Country.Name,
                    Name = item.Name
                });
            }
            return ApiResponseFactory<List<CityDTO>>.SuccessResponse(allCitiesDtos, HttpStatusCode.OK, "Success");
        }*/
    }
}
