using AutoMapper;
using MirrorLink.Application.Features.Person.Models;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Application.Profiles
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonModel>().ReverseMap();
        }
    }
}
