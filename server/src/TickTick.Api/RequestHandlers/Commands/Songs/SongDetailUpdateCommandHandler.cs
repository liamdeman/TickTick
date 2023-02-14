using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Songs;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Songs;

public struct SongDetailUpdateCommand : IRequest
{
    public required Guid Id { get; init; }
    public required SongDetailDto Song { get; init; }
}

public class SongDetailUpdateCommandHandler : IRequestHandler<SongDetailUpdateCommand>
{
    private readonly IRepository<Song> _songsRepository;
    private readonly IMapper _mapper;

    public SongDetailUpdateCommandHandler(IRepository<Song> songsRepository, IMapper mapper)
    {
        _songsRepository = songsRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(SongDetailUpdateCommand request, CancellationToken cancellationToken)
    {
        var song = await _songsRepository
            .GetAll()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);
        
        _mapper.Map(request.Song, song);
        await _songsRepository.SaveAsync();

        return Unit.Value;
    }
}