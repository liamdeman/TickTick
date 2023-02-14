namespace TickTick.Models;

public abstract class PlaylistItem : BaseEntity
{
    public string Title { get; set; }
    public TimeSpan? Duration { get; set; }
    public uint SequenceNumber { get; set; }
    public Playlist Playlist { get; set; }
    public Guid PlaylistId { get; set; }
}