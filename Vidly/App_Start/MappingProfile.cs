using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    //class for configuring auto mapper
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapping for customers

            //domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            //dto to domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());

            //mapping for movie
            
            //domain to dto
            Mapper.CreateMap<Movie, MovieDto>();
            //dto to domain
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            //mapper for membership type

            //domain to dto
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            //dto to domain
            Mapper.CreateMap<MembershipTypeDto, MembershipType>().ForMember(m => m.Id, opt => opt.Ignore());

            //mapping for genre

            //domain to dto
            Mapper.CreateMap<Genre, GenreDto>();
            //dto to map
            Mapper.CreateMap<GenreDto, Genre>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}