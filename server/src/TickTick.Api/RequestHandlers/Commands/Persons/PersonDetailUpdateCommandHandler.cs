using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Commands.Persons;

public struct PersonDetailUpdateCommand : IRequest
{
    public required Guid PublicId { get; init; }
    public required PersonDetailDto Person { get; init; }
}

public class PersonDetailUpdateCommandHandler : IRequestHandler<PersonDetailUpdateCommand>
{
    private readonly IRepository<Person> _repository;
    private readonly IMapper _mapper;

    public PersonDetailUpdateCommandHandler(IRepository<Person> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PersonDetailUpdateCommand request, CancellationToken cancellationToken)
    {
        var person = await _repository.GetAll()
            .SingleAsync(x => x.Id == request.PublicId, cancellationToken);

        _mapper.Map(request.Person, person);
        
        _repository.UpdateAsync(person);
        return Unit.Value;
    }
}