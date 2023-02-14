using AutoMapper;
using TickTick.Models;

namespace TickTick.Api.Dtos.Songs;

public class SongsMappingProfile : Profile
{
    public SongsMappingProfile()
    {
        CreateMap<SongCreateDto, Song>();
        CreateMap<Song, SongOverviewDto>();
        CreateMap<Song, SongDetailDto>().ReverseMap();
    }
}