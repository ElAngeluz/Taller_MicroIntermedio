using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IPersonRepository IPerson;
        private readonly IClientRepository IClient;

        public ClientsController(IMapper mapper, IPersonRepository iPerson)
        {
            _mapper = mapper;
            IPerson = iPerson;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> GetClient()
        {
            var result = await IClient.GetAllAsync();
            var mappedUser = _mapper.Map<List<ClientDTO>>(result);

            return Ok(mappedUser);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(Guid id)
        {
            var client = await IClient.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ClientDTO>(client);


            return result;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutClient(ClientDTO clientDTO)
        {
            var result = _mapper.Map<Client>(clientDTO);
            await IClient.UpdateAsync(result);

            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientDTO ClientDTO)
        {
            var result = _mapper.Map<Client>(ClientDTO);
            result.ClientId = Guid.NewGuid();
            result.PersonNav.Id = Guid.NewGuid();
            var client = await IClient.AddAsync(result);

            return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await IClient.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            await IClient.DeleteAsync(client);

            return NoContent();
        }

    }
}
