using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Persons;

public record PersonDeleteCommand : IRequest
{
    public required Guid PublicId { get; set; }
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
        await _repository.GetAll()
            .Where(x => x.Id == request.PublicId)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
}