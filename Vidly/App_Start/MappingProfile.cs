using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, opt => opt.Ignore());//map all the name equal properties
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();


        }
    }
}