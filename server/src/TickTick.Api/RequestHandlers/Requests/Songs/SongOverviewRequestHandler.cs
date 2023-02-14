using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Songs;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.Songs;

public struct SongOverviewRequest : IRequest<IQueryable<SongOverviewDto>>
{

}

public class SongOverviewRequestHandler : IRequestHandler<SongOverviewRequest, IQueryable<SongOverviewDto>>
{
    private readonly IRepository<Song> _songsRepository;
    private readonly IMapper _mapper;

    public SongOverviewRequestHandler(IRepository<Song> songsRepository, IMapper mapper)
    {
        _songsRepository = songsRepository;
        _mapper = mapper;
    }

    public async Task<IQueryable<SongOverviewDto>> Handle(SongOverviewRequest request, CancellationToken cancellationToken)
    {
        return _mapper.ProjectTo<SongOverviewDto>(_songsRepository.GetAll());
    }
}