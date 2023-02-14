using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Speeches;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Speeches;

public struct SpeechCreateCommand : IRequest<Guid>
{
    public required SpeechCreateDto Speech { get; init; }
}

public class SpeechCreateCommandHandler : IRequestHandler<SpeechCreateCommand, Guid>
{
    private readonly IRepository<Speech> _speechesRepository;
    private readonly IMapper _mapper;

    public SpeechCreateCommandHandler(IRepository<Speech> speechesRepository, IMapper mapper)
    {
        _speechesRepository = speechesRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(SpeechCreateCommand request, CancellationToken cancellationToken)
    {
        var speech = _mapper.Map<Speech>(request.Speech);
        
        _speechesRepository.Add(speech);
        await _speechesRepository.SaveAsync();

        return speech.Id;
    }
}