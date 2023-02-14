using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Playlists;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.Playlists;

public struct PlaylistDetailRequest : IRequest<PlaylistDetailDto>
{
    public required Guid Id { get; init; }
}

public class PlaylistDetailRequestHandler : IRequestHandler<PlaylistDetailRequest, PlaylistDetailDto>
{
    private readonly IRepository<Playlist> _repository;
    private readonly IMapper _mapper;

    public PlaylistDetailRequestHandler(IRepository<Playlist> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PlaylistDetailDto> Handle(PlaylistDetailRequest request, CancellationToken cancellationToken)
    {
        var playlist = await _repository.GetAll()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);

        return _mapper.Map<PlaylistDetailDto>(playlist);
    }
}