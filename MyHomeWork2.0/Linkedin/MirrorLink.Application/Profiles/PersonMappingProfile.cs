
using AutoMapper;
using Microsoft.Domain.Entities;
using MirrorLink.Application.Features.Person.Models;

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
