using MediatR;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos.Songs;
using TickTick.Api.RequestHandlers.Commands.Songs;
using TickTick.Api.RequestHandlers.Requests.Songs;

namespace TickTick.Api.Controllers;

public class SongsController : ApiControllerBase
{
    public SongsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<Guid> Create([FromBody] SongCreateDto input, [FromQuery] Guid? previousItemId, [FromQuery] Guid? nextItemId)
    {
        return await _mediator.Send(new SongCreateCommand
        {
            Song = input,
            PreviousItemId = previousItemId,
            NextItemId = nextItemId
        });
    }

    [HttpGet]
    public async Task<IQueryable<SongOverviewDto>> Get()
    {
        return await _mediator.Send(new SongOverviewRequest());
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<SongDetailDto> Get(Guid id)
    {
        return await _mediator.Send(new SongDetailRequest
        {
            Id = id
        });
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task Update(Guid id, SongDetailDto input)
    {
        await _mediator.Send(new SongDetailUpdateCommand
        {
            Id = id,
            Song = input
        });
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _mediator.Send(new SongDeleteCommand
        {
            Id = id
        });
    }
    
}