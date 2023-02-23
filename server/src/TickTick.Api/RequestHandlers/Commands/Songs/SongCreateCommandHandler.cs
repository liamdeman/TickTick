using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Songs;
using TickTick.Api.RequestHandlers.Requests.PlaylistItems;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Songs;

public struct SongCreateCommand : IRequest<Guid>
{
    public required SongCreateDto Song { get; init; }
    public Guid? PreviousItemId { get; init; }
    public Guid? NextItemId { get; init; }
}

public class SongCreateCommandHandler : IRequestHandler<SongCreateCommand, Guid>
{
    private readonly IRepository<Song> _repository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SongCreateCommandHandler(IRepository<Song> repository, IMapper mapper, IMediator mediator)
    {
        _repository = repository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(SongCreateCommand request, CancellationToken cancellationToken)
    {
        var song = _mapper.Map<Song>(request.Song);
        song.SequenceNumber = await _mediator.Send(new PlaylistItemGenerateSequenceNumberRequest
        {
            NextItemId = request.NextItemId,
            PreviousItemId = request.PreviousItemId
        }, cancellationToken);
        _repository.AddAsync(song);

        return song.Id;
    }
}