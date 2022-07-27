using MediatR;
using MirrorLink.Application.Features.Person.Models;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace MirrorLink.Application.Features.Person.Queries.PostPerson
{
    public class PostPersonListQuery : IRequest<PersonModel>
    {
        public PersonModel Model { get; set; }

        public PostPersonListQuery(PersonModel person)
        {
            Model = person;
        }
    }
}
