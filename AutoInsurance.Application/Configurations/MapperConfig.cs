using AutoMapper;
using AutoInsurance.Application.DTOs.Policy;
using AutoInsurance.Domain.Entities;

namespace AutoInsurance.Api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Policy, PolicyDto>().ReverseMap();
            CreateMap<Policy, CreatePolicyDto>().ReverseMap();
        }
    }
}
