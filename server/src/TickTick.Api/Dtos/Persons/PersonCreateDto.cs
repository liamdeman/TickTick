namespace TickTick.Api.Dtos.Persons;

public record PersonCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string Email { get; set; }
}