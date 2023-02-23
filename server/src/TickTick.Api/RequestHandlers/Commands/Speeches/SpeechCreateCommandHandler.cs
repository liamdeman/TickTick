using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Speeches;
using TickTick.Api.RequestHandlers.Requests.PlaylistItems;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Speeches;

public struct SpeechCreateCommand : IRequest<Guid>
{
    public required SpeechCreateDto Speech { get; init; }
    public Guid? PreviousItemId { get; init; }
    public Guid? NextItemId { get; init; }
}

public class SpeechCreateCommandHandler : IRequestHandler<SpeechCreateCommand, Guid>
{
    private readonly IRepository<Speech> _speechesRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SpeechCreateCommandHandler(IRepository<Speech> speechesRepository, IMapper mapper, IMediator mediator)
    {
        _speechesRepository = speechesRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(SpeechCreateCommand request, CancellationToken cancellationToken)
    {
        var speech = _mapper.Map<Speech>(request.Speech);
        speech.SequenceNumber = await _mediator.Send(new PlaylistItemGenerateSequenceNumberRequest
        {
            NextItemId = request.NextItemId,
            PreviousItemId = request.PreviousItemId
        }, cancellationToken);
        _speechesRepository.AddAsync(speech);

        return speech.Id;
    }
}