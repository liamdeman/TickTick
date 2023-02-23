namespace TickTick.Api.Dtos.Songs;

public record SongDetailDto
{
        public string Song { get; set; }
        public string Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public double SequenceNumber { get; set; }

}