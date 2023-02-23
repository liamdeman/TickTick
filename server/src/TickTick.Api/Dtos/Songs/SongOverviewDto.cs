namespace TickTick.Api.Dtos.Songs;

public record SongOverviewDto
{
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public double SequenceNumber { get; set; }
}