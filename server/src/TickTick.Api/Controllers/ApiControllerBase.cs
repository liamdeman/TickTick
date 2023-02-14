using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace TickTick.Api.Controllers;

[Route("v{v:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[EnableQuery]
public class ApiControllerBase : ControllerBase
{
    protected readonly IMediator _mediator;
    public ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

}