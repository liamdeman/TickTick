namespace TickTick.Api.Dtos.Playlists;

public record PlaylistOverviewDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
}