using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taller.Domain.Entities;
using Taller.Application.DTOs;
using Taller.Application.Interfaces.Repositories;
using System;

namespace Taller.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("/persona")]
    public class PersonController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository IPerson;

        public PersonController(IMapper mapper,
                                IPersonRepository iPerson)
        {
            _mapper = mapper;
            IPerson = iPerson;
        }

        [HttpGet("{Id}")]
        public IActionResult GetPerson(Guid? Id) 
        {
            if (Id is null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            var person = IPerson.GetByIdAsync(Id.Value);

            if (person is null)
            {
                throw new NullReferenceException($"no se ha podido encontrar una entidad con la Identificacion: {Id}");
            }

            //var userViewModel = _mapper.Map<PersonDTO>(person);
            return Ok();
        }

    }
}
