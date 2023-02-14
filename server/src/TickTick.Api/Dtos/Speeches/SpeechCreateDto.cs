namespace TickTick.Api.Dtos.Speeches;

public record SpeechCreateDto
{
    public string Title { get; set; }
    public TimeSpan? Duration { get; set; }
    public uint SequenceNumber { get; set; }
    public Guid PlaylistId { get; set; }
}