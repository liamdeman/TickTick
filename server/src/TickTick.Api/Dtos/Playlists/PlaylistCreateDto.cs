namespace TickTick.Api.Dtos.Playlists;

public record PlaylistCreateDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Guid PersonId { get; set; }    
}