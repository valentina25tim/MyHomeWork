using MirrorLink.Application.Features.Person.Models;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using MediatR;

namespace MirrorLink.Application.Features.Pet.Queries.GetPetDetailQuery
{
    public class GetPetDetailQuery : IRequest<PetModel>
    {
        public int Id { get; set; }
    }
}
