using MediatR;
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
        await _repository.DeleteAsync(request.Id);

        return Unit.Value;
    }
}