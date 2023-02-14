using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Playlists;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.Playlists;

public struct PlaylistOverviewRequest : IRequest<IQueryable<PlaylistOverviewDto>>
{
    
}

public class PlaylistOverviewRequestHandler : IRequestHandler<PlaylistOverviewRequest, IQueryable<PlaylistOverviewDto>>
{
    private readonly IRepository<Playlist> _repository;
    private readonly IMapper _mapper;

    public PlaylistOverviewRequestHandler(IMapper mapper, IRepository<Playlist> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IQueryable<PlaylistOverviewDto>> Handle(PlaylistOverviewRequest request, CancellationToken cancellationToken)
    {
        return _mapper.ProjectTo<PlaylistOverviewDto>(_repository.GetAll());
    }
}