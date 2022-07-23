using MediatR;
using MirrorLink.Application.Features.Person.Models;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace MirrorLink.Application.Features.Pet.Queries.GetPetList
{
    public class GetPetListQuery : IRequest<List<PetModel>>
    {
    }
}