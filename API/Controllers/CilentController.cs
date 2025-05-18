using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using AmazonTours.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using AmazonTours.Application.DTOs.ReadDTOs;
using Amazon_Tours.Utilities.ApiResponses.Factory;
using System.Net;
using AutoMapper;
using AmazonTours.Application.Services;
using AmazonTours.Application.Utilities.Extensions;
using AmazonTours.Application.DTOs.CreateDTOs;
using Models;
using AmazonTours.Application.DTOs.UpdateDTOs;
using Azure;
using Microsoft.AspNetCore.Mvc;
namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CilentController : AppBaseController<Client>
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public CilentController(IClientService clientService, IMapper mapper) : base (clientService)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetClient(Guid clientId, int pageNumber = 1, int pageSize = 10)
        {
            if(clientId == Guid.Empty)
            {
                var clients = (await _clientService
                                .GetAllAsync(pageNumber, pageSize, client => client.Country, client => client.City))
                                .ToDTOCollection<Client, ClientDTO>(_mapper);

                return OkResponse(clients);
            }

            var idExistence = await CheckExistedId(clientId);
            if (idExistence.IsExisted)
            {
                return OkResponse(idExistence.Entity.ToDTO<Client>(_mapper));
            }
            return NotFoundResponse();
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddNewClient(CreateClientDTO createClientDTO)
        {
            if(ModelState.IsValid)
            {
                var newClientId = await _clientService.AddAsync(createClientDTO.ToEntity<Client>(_mapper));
                return OkResponse(newClientId);
            }

            return InValidModelState();
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            if ((await CheckExistedId(clientId)).IsExisted)
            {
                await _clientService.DeleteByIdAsync(clientId);
                return OkResponse(clientId);
            }

            return NotFoundResponse();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateClient(Guid clientId,  UpdateClientDTO updateClientDTO)
        {
            if (ModelState.IsValid)
            {
                var updatedClient = await _clientService.UpdateAsync(clientId, updateClientDTO.ToEntity<Client>(_mapper));
                return OkResponse(updatedClient);
            }

            return InValidModelState();
        }
    }
}
