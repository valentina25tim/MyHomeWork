using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirrorLink.Application.Features.Person.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<int>
    { 
        public string Country { get; set; }
        public string City { get; set; }
    }
}
