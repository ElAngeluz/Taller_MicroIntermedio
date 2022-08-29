using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taller.Application.DTOs;
using Taller.Application.Interfaces.Repositories;
using Taller.Domain.Entities;

namespace Taller.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("/cliente")]
    public class ClientsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _IClient;
        private readonly ILogger _logger;

        public ClientsController(IMapper mapper,
                                 ILogger<ClientsController> logger,
                                 IClientRepository iClient)
        {
            _mapper = mapper;
            _logger = logger;
            _IClient = iClient;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<List<ClientResponseDTO>>> GetClient()
        {
            _logger.LogInformation("Se procede a consultar todos los clientes");
            var result = await _IClient.GetAllAsync();
            var mappedUser = _mapper.Map<List<ClientResponseDTO>>(result);

            return Ok(mappedUser);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponseDTO>> GetClient(Guid id)
        {
            var client = await _IClient.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ClientResponseDTO>(client);


            return result;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutClient(ClientRequestDTO clientDTO)
        {
            var result = _mapper.Map<Client>(clientDTO);
            await _IClient.UpdateAsync(result);

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<ClientResponseDTO>> PostClient(ClientRequestDTO ClientDTO)
        {
            if (ClientDTO.ClientId is not null)
            {
                var client1 = await _IClient.GetByIdAsync(ClientDTO.ClientId.Value);
                if (client1 is not null) throw new Exception("El identificador unico del cliente ya existe");
            }

            var person = await _IClient.GetByIdAsync(ClientDTO.Identification);

            if (person is not null)
            {
                throw new Exception("el Cliente ya existe en la base de datos");
            }

            var result = _mapper.Map<Client>(ClientDTO);
            result.ClientId = Guid.NewGuid();
            result.PersonNav.Id = Guid.NewGuid();
            var client = await _IClient.AddAsync(result);
            var clientResponseDTO = _mapper.Map<ClientResponseDTO>(client);


            return CreatedAtAction("GetClient", new { id = client.ClientId }, clientResponseDTO);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await _IClient.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            await _IClient.DeleteAsync(client);

            return NoContent();
        }

    }
}
