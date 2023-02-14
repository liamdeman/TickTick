using MediatR;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos.Speeches;
using TickTick.Api.RequestHandlers.Commands.Speeches;
using TickTick.Api.RequestHandlers.Requests.Speeches;

namespace TickTick.Api.Controllers;

public class SpeechesController : ApiControllerBase
{
    public SpeechesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<Guid> Create(SpeechCreateDto input)
    {
        return await _mediator.Send(new SpeechCreateCommand
        {
            Speech = input
        });
    }

    [HttpGet]
    public async Task<IQueryable<SpeechOverviewDto>> Get()
    {
        return await _mediator.Send(new SpeechOverviewRequest());
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<SpeechDetailDto> Get(Guid id)
    {
        return await _mediator.Send(new SpeechDetailRequest
        {
            Id = id
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task Update(Guid id, SpeechDetailDto input)
    {
        await _mediator.Send(new SpeechDetailUpdateCommand
        {
            Speech = input,
            Id = id
        });
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _mediator.Send(new SpeechDeleteCommand
        {
            Id = id
        });
    }
}