using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.Persons;

public class PersonDetailRequest : IRequest<PersonDetailDto>
{
    public required Guid PublicId { get; init; }
}

public class PersonDetailRequestHandler : IRequestHandler<PersonDetailRequest, PersonDetailDto>
{
    private readonly IRepository<Person> _repository;
    private readonly IMapper _mapper;

    public PersonDetailRequestHandler(IRepository<Person> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PersonDetailDto> Handle(PersonDetailRequest request, CancellationToken cancellationToken)
    {
        var person = await _repository.GetAll()
            .SingleAsync(x => x.Id == request.PublicId, cancellationToken);

        return _mapper.Map<PersonDetailDto>(person);
    }
}