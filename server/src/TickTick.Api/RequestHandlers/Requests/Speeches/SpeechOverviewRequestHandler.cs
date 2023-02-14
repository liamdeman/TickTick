using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Speeches;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.Speeches;

public struct SpeechOverviewRequest : IRequest<IQueryable<SpeechOverviewDto>>
{
    
}

public class SpeechOverviewRequestHandler : IRequestHandler<SpeechOverviewRequest, IQueryable<SpeechOverviewDto>>
{
    private readonly IRepository<Speech> _speechesRepository;
    private readonly IMapper _mapper;

    public SpeechOverviewRequestHandler(IRepository<Speech> speechesRepository, IMapper mapper)
    {
        _speechesRepository = speechesRepository;
        _mapper = mapper;
    }

    public async Task<IQueryable<SpeechOverviewDto>> Handle(SpeechOverviewRequest request, CancellationToken cancellationToken)
    {
        return _mapper.ProjectTo<SpeechOverviewDto>(_speechesRepository.GetAll());
    }
}