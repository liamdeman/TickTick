namespace TickTick.Api.Dtos.Speeches;

public record SpeechDetailDto
{
    public string Title { get; set; }
    public TimeSpan? Duration { get; set; }
    public double SequenceNumber { get; set; }
    public string? Speaker { get; set; }
    public string Text { get; set; }
}