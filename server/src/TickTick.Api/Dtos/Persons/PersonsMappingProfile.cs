using AutoMapper;
using TickTick.Models;

namespace TickTick.Api.Dtos.Persons;

public class PersonsMappingProfile : Profile
{
    public PersonsMappingProfile()
    {
        CreateMap<Person, PersonDetailDto>().ReverseMap();
        CreateMap<PersonCreateDto, Person>();
        CreateMap<Person, PersonOverviewDto>();
    }
}