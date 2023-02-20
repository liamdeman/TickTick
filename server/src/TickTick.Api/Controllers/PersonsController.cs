using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos.Persons;
using TickTick.Api.RequestHandlers.Commands.Persons;
using TickTick.Api.RequestHandlers.Requests.Persons;

namespace TickTick.Api.Controllers;

[Authorize]
public class PersonsController : ApiControllerBase
{
    public PersonsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet] 
    public async Task<IQueryable<PersonOverviewDto>> Get()
    {
        return await _mediator.Send(new PersonOverviewRequest());
    }


    [HttpGet("{id:guid}")]
    public async Task<PersonDetailDto> Get(Guid id)
    {
        return await _mediator.Send(new PersonDetailRequest
        {
            PublicId = id
        });
    }

    [HttpPost]
    public async Task<Guid> Create(PersonCreateDto input)
    {
        return await _mediator.Send(new PersonCreateCommand
        {
            Person = input
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task Update(Guid id, PersonDetailDto input)
    {
        await _mediator.Send(new PersonDetailUpdateCommand
        {
            PublicId = id,
            Person = input
        });
    }
        
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new PersonDeleteCommand
        {
            Id = id
        });
        return NoContent();
    }


}