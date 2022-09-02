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
using MirrorLink.Application.Contracts.Models;
using MirrorLink.Application.Features.Address.Queries.GetPersonList;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace MirrorLink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AddressController> _logger;
        private readonly IMapper _mapper;

        public AddressController(IMediator mediator, ILogger<AddressController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AddressModel>>> GetAllAddress()
        {
            var response = await _mediator.Send(new GetAddressListQuery());

            _logger.LogInformation("Get query - return AddressModel, Ok");

            return Ok(response);
        }

    }
}
