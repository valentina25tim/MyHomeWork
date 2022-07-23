using MediatR;
using MirrorLink.Application.Features.Person.Models;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MirrorLink.Application.Features.Person.Queries.GetPersonDetailQuery
{
    public class GetPersonDetailQuery : IRequest<PersonModel>
    {
        public int Id { get; set; }
    }
}
