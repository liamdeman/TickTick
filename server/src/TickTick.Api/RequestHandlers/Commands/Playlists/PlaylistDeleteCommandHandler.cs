using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Playlists;

public struct PlaylistDeleteCommand : IRequest
{
    public required Guid Id { get; init; }
}

public class PlaylistDeleteCommandHandler : IRequestHandler<PlaylistDeleteCommand>
{
    private readonly IRepository<Playlist> _repository;

    public PlaylistDeleteCommandHandler(IRepository<Playlist> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(PlaylistDeleteCommand request, CancellationToken cancellationToken)
    {
        await _repository.GetAll()
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);

        return Unit.Value;
    }
}