using MediatR;
using Microsoft.Data.SqlClient;
using MirrorLink.Application.Contracts.Models;
using System;
using System.Data;

namespace MirrorLink.Application.Features.Person.Queries.GetPersonList
{
    public class GetPersonDetailQuery : IRequest<PersonModel>
    {
        public int Id { get; set; }
    }
}