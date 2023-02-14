using MediatR;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos.Playlists;
using TickTick.Api.RequestHandlers.Commands.Playlists;
using TickTick.Api.RequestHandlers.Requests.Playlists;

namespace TickTick.Api.Controllers;

public class PlaylistController : ApiControllerBase
{
    public PlaylistController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost]
    public async Task<Guid> Create(PlaylistCreateDto input)
    {
           return await _mediator.Send(new PlaylistCreateCommand
           {
               Playlist = input
           }) ;
    }

    [HttpGet]
    public async Task<IQueryable<PlaylistOverviewDto>> Get()
    {
        return await _mediator.Send(new PlaylistOverviewRequest());
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<PlaylistDetailDto> Get(Guid id)
    {
        return await _mediator.Send(new PlaylistDetailRequest
        {
            Id = id
        });
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task Update(Guid id, PlaylistDetailDto input)
    {
        await _mediator.Send(new PlaylistDetailUpdateCommand
        {
            Id = id,
            Playlist = input
        });
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new PlaylistDeleteCommand
        {
            Id = id
        });
        
        return NoContent();
    }
}