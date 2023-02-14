using MediatR;

namespace TickTick.Api.RequestHandlers;

public abstract class CommandBase<T> : IRequest<T>
{
    
}