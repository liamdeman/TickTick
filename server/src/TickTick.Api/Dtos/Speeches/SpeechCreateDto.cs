namespace TickTick.Api.Dtos.Speeches;

public record SpeechCreateDto
{
    public string Title { get; set; }
    public TimeSpan? Duration { get; set; }
    public double SequenceNumber { get; set; }
    public Guid PlaylistId { get; set; }
}