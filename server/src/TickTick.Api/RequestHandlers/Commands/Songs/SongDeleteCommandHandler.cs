using MediatR;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Songs;

public struct SongDeleteCommand : IRequest
{
    public required Guid Id { get; init; }
}

public class SongDeleteCommandHandler : IRequestHandler<SongDeleteCommand>
{
    private readonly IRepository<Song> _songRepository;

    public SongDeleteCommandHandler(IRepository<Song> songRepository)
    {
        _songRepository = songRepository;
    }

    public async Task<Unit> Handle(SongDeleteCommand request, CancellationToken cancellationToken)
    {
        await _songRepository.DeleteAsync(request.Id);
        
        return Unit.Value;
    }
}