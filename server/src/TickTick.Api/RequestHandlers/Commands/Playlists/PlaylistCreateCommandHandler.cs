using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Playlists;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Playlists;

public struct PlaylistCreateCommand : IRequest<Guid>
{
    public required PlaylistCreateDto Playlist { get; init; }
}

public class PlaylistCreateCommandHandler : IRequestHandler<PlaylistCreateCommand, Guid>
{
    private readonly IRepository<Playlist> _repository;
    private readonly IMapper _mapper;

    public PlaylistCreateCommandHandler(IRepository<Playlist> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(PlaylistCreateCommand request, CancellationToken cancellationToken)
    {
        var playlist = _mapper.Map<Playlist>(request.Playlist);
        _repository.AddAsync(playlist);
        return playlist.Id;
    }
}