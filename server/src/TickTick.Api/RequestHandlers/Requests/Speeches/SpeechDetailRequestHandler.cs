using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Speeches;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.Speeches;

public struct SpeechDetailRequest : IRequest<SpeechDetailDto>
{
    public required Guid Id { get; init; }
}

public class SpeechDetailRequestHandler : IRequestHandler<SpeechDetailRequest, SpeechDetailDto>
{
    private readonly IRepository<Speech> _speechesRepository;
    private readonly IMapper _mapper;

    public SpeechDetailRequestHandler(IRepository<Speech> speechesRepository, IMapper mapper)
    {
        _speechesRepository = speechesRepository;
        _mapper = mapper;
    }

    public async Task<SpeechDetailDto> Handle(SpeechDetailRequest request, CancellationToken cancellationToken)
    {
        var speech = await _speechesRepository
            .GetAll()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);
        
        return _mapper.Map<SpeechDetailDto>(speech);
    }
}