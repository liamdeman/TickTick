namespace TickTick.Api.Dtos.Songs;

public record SongCreateDto
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public Guid PlaylistId { get; set; }
    public TimeSpan? Duration { get; set; }
}