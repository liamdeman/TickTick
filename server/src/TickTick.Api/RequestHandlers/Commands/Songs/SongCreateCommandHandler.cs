using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Songs;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Songs;

public struct SongCreateCommand : IRequest<Guid>
{
    public required SongCreateDto Song { get; init; }
}

public class SongCreateCommandHandler : IRequestHandler<SongCreateCommand, Guid>
{
    private readonly IRepository<Song> _repository;
    private readonly IMapper _mapper;

    public SongCreateCommandHandler(IRepository<Song> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(SongCreateCommand request, CancellationToken cancellationToken)
    {
        var song = _mapper.Map<Song>(request.Song);
        
        _repository.AddAsync(song);

        return song.Id;
    }
}