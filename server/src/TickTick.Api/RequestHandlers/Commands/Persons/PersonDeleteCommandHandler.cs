using MediatR;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Persons;

public record PersonDeleteCommand : IRequest
{
    public required Guid Id { get; set; }
}

public class PersonDeleteCommandHandler : IRequestHandler<PersonDeleteCommand>
{
    private readonly IRepository<Person> _repository;

    public PersonDeleteCommandHandler(IRepository<Person> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(PersonDeleteCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}