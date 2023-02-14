using AutoMapper;
using MediatR;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.Persons;

public class PersonOverviewRequest : IRequest<IQueryable<PersonOverviewDto>>
{
}

public class PersonOverviewRequestHandler : IRequestHandler<PersonOverviewRequest, IQueryable<PersonOverviewDto>>
{
    private readonly IRepository<Person> _repository;
    private readonly IMapper _mapper;

    public PersonOverviewRequestHandler(IRepository<Person> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IQueryable<PersonOverviewDto>> Handle(PersonOverviewRequest request, CancellationToken cancellationToken)
    {
        return _mapper.ProjectTo<PersonOverviewDto>(_repository.GetAll());
    }
}