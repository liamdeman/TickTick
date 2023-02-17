using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Speeches;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Speeches;

public struct SpeechDetailUpdateCommand : IRequest
{
    public required Guid Id { get; init; }
    public required SpeechDetailDto Speech { get; init; }
}

public class SpeechDetailUpdateCommandHandler : IRequestHandler<SpeechDetailUpdateCommand>
{
    private readonly IRepository<Speech> _speechesRepository;
    private readonly IMapper _mapper;

    public SpeechDetailUpdateCommandHandler(IRepository<Speech> speechesRepository, IMapper mapper)
    {
        _speechesRepository = speechesRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(SpeechDetailUpdateCommand request, CancellationToken cancellationToken)
    {
        var speech = await _speechesRepository.GetAll()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);

        _mapper.Map(request.Speech, speech);

        _speechesRepository.UpdateAsync(speech);

        return Unit.Value;
    }
}