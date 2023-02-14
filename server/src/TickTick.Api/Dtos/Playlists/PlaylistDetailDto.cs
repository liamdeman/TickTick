namespace TickTick.Api.Dtos.Playlists;

public record PlaylistDetailDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
}