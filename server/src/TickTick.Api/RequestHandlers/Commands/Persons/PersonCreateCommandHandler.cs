using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Persons;

public record PersonCreateCommand : IRequest<Guid>
{
    public required PersonCreateDto Person { get; init; }
}

public class PersonCreateCommandHandler : IRequestHandler<PersonCreateCommand, Guid>
{
    private readonly IRepository<Person> _repository;
    private readonly IMapper _mapper;

    public PersonCreateCommandHandler(IRepository<Person> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<Guid> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request.Person);
        _repository.Add(person);
        await _repository.SaveAsync();
        return person.Id;
    }
}