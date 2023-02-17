using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Playlists;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Playlists;

public struct PlaylistDetailUpdateCommand : IRequest
{
    public required Guid Id { get; init; }
    public required PlaylistDetailDto Playlist { get; init; }
}

public class PlaylistDetailUpdateCommandHandler : IRequestHandler<PlaylistDetailUpdateCommand>
{
    private readonly IRepository<Playlist> _repository;
    private readonly IMapper _mapper;

    public PlaylistDetailUpdateCommandHandler(IRepository<Playlist> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PlaylistDetailUpdateCommand request, CancellationToken cancellationToken)
    {
        var playlist = await _repository.GetAll()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);
        
        _mapper.Map(request.Playlist, playlist);
        
        _repository.UpdateAsync(playlist);
        return Unit.Value;
    }
}