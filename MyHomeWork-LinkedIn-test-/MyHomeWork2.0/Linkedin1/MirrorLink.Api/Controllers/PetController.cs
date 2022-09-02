using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MirrorLink.Application.Features.Person.Queries.GetPersonList;
using Raven.Client.Documents.Operations.Revisions;
using Microsoft.Extensions.Logging;
using AutoMapper;
using MirrorLink.Application.Features.Person.Models;
using MirrorLink.Application.Features.Pet.Queries.GetPetList;
using MirrorLink.Application.Features.Pet.Queries.GetPetDetailQuery;

namespace MirrorLink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PetController> _logger;
        private readonly IMapper _mapper;

        public PetController(IMediator mediator, ILogger<PetController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PetModel>>> GetAllPets()
        {
            _logger.LogInformation("Requested a Pet API");

            try
            {
                var response = await _mediator.Send(new GetPetListQuery());
                _logger.LogInformation("Request 'Ok'");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught - PetController");

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PetModel>>> FindPet(int id)
        {
            // TODO add handler for this
            // in progress
            _logger.LogInformation("Requested a Pet API (Id)");

            try
            {
                var response = await _mediator.Send(new GetPetDetailQuery
                {
                    Id = _mapper.Map<int>(id)
                },
                HttpContext.RequestAborted);

                _logger.LogInformation("Get query - return PetModel");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");

                return BadRequest(ex.Message);
            }
        }
    }
}
