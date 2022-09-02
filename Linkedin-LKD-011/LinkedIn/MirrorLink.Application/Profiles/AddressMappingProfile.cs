using AutoMapper;
using MirrorLink.Application.Contracts.Models;
using MirrorLink.Business.Entities;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Application.Profiles
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<AddressModel,Address> ().ReverseMap();// reverse - mapping works in both direction 
        }
    }
}
