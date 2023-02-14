using AutoMapper;
using TickTick.Models;

namespace TickTick.Api.Dtos.Playlists;

public class PlaylistMappingProfile : Profile
{
    public PlaylistMappingProfile()
    {
        CreateMap<PlaylistCreateDto, Playlist>();
        CreateMap<Playlist, PlaylistOverviewDto>();
        CreateMap<Playlist, PlaylistDetailDto>().ReverseMap();
    }
}