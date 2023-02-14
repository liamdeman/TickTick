namespace TickTick.Api.Dtos.Persons;

public record PersonDetailDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; }
}