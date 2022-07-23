using AutoMapper;
using MirrorLink.Application.Features.Person.Models;
using MirrorLink.Domain.Entities;


namespace MirrorLink.Application.Profiles
{
    public class PetMappingProfile : Profile
    {
        public PetMappingProfile()
        {
            CreateMap<Pet, PetModel>().ReverseMap();
        }
    }
}
