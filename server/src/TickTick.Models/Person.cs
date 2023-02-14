namespace TickTick.Models;

public class Person : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? SocialSecurityNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; }
    public IEnumerable<Playlist> Playlists { get; set; }

}