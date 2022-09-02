using AutoMapper;
using MirrorLink.Application.Contracts.Models;
using MirrorLink.Business.Entities;
using MirrorLink.Domain.Entities;
using System.Linq;

namespace MirrorLink.Application.Profiles
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonModel>().ReverseMap();

            
            
            
            
            
            //CreateMap<AddressModel, Person>().ReverseMap().ConvertUsing<PersonWithAddressConverter>();
        }
    }
    //public class PersonWithAddressConverter : ITypeConverter<AddressModel, Person>
    //{
    //    public Person Convert(AddressModel source, Person destination, ResolutionContext context)
    //    {
    //        return new Person
    //        {
    //            Address = new Address
    //            {
    //                Country = source.Country,
    //                City = source.City
    //            }
    //        };
    //    }
    //}


}
