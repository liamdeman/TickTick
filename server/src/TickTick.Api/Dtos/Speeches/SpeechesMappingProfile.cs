using AutoMapper;
using TickTick.Models;

namespace TickTick.Api.Dtos.Speeches;

public class SpeechesMappingProfile : Profile
{
    public SpeechesMappingProfile()
    {
        CreateMap<SpeechCreateDto, Speech>();
        CreateMap<Speech, SpeechOverviewDto>();
        CreateMap<Speech, SpeechDetailDto>().ReverseMap();
    }
}