namespace TickTick.Api.Dtos.Persons;

public record PersonOverviewDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}