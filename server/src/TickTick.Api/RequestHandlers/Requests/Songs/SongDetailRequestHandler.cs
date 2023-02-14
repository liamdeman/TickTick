using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Songs;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.Songs;

public struct SongDetailRequest : IRequest<SongDetailDto>
{
    public required Guid Id { get; init; }
}

public class SongDetailRequestHandler : IRequestHandler<SongDetailRequest, SongDetailDto>
{
    private readonly IRepository<Song> _songsRepository;
    private readonly IMapper _mapper;

    public SongDetailRequestHandler(IRepository<Song> songsRepository, IMapper mapper)
    {
        _songsRepository = songsRepository;
        _mapper = mapper;
    }

    public async Task<SongDetailDto> Handle(SongDetailRequest request, CancellationToken cancellationToken)
    {
        var song = await _songsRepository.GetAll()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);

        return _mapper.Map<SongDetailDto>(song);
    }
}