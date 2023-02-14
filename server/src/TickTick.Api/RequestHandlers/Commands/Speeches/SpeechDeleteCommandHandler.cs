using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Speeches;

public struct SpeechDeleteCommand : IRequest
{
    public required Guid Id { get; init; }
}

public class SpeechDeleteCommandHandler : IRequestHandler<SpeechDeleteCommand>
{
    private readonly IRepository<Speech> _speechesRepository;

    public SpeechDeleteCommandHandler(IRepository<Speech> speechesRepository)
    {
        _speechesRepository = speechesRepository;
    }

    public async Task<Unit> Handle(SpeechDeleteCommand request, CancellationToken cancellationToken)
    {
        await _speechesRepository.GetAll()
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);

        return Unit.Value;
    }
}