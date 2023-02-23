namespace TickTick.Api.Dtos.Speeches;

public record SpeechOverviewDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Speaker { get; set; }
    public double SequenceNumber { get; set; }
}   