using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MirrorLink.Application.Contracts.Models;
using MirrorLink.Application.Features.Person.Queries.GetPersonDetail;
using MirrorLink.Application.Features.Person.Queries.GetPersonList;
using MirrorLink.Application.Features.Person.Queries.PostPerson;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PersonController> _logger;
        private readonly IMapper _mapper;

        public PersonController(IMediator mediator, ILogger<PersonController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet (nameof(GetAllPersons), Name = nameof(GetAllPersons))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PersonModel>>> GetAllPersons()
        {
            _logger.LogInformation("Requested a Person API");

            try
            {
                var response = await _mediator.Send(new GetPersonListQuery());
                _logger.LogInformation("Request 'Ok'");
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught - PersonController"); 
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = nameof(FindPerson)) ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PersonModel>>> FindPerson(int id)
        {
            _logger.LogInformation("Requested a Person API (Id)");

            try
            {
                var response = await _mediator.Send(new GetPersonDetailQuery
                {
                    Id = _mapper.Map<int>(id)
                },
                HttpContext.RequestAborted);

                _logger.LogInformation("Get query - return PersonModel");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");

                return BadRequest(ex.Message);
            }
        }

        [HttpPost(nameof(PostPerson), Name = nameof(PostPerson))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PersonModel>>> PostPerson([FromBody] PersonModel person)
        {
            _logger.LogInformation("Requested a Person API");
           
            // need toDo Validation and correct Id(not inputed)
            try
            {
                var response = await _mediator.Send(new PostPersonListQuery(person));

                _logger.LogInformation("Request 'Ok'");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught - PersonController");

                return BadRequest(ex.Message);
            }
        }
    }
}
