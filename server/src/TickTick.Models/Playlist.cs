namespace TickTick.Models;

public class Playlist : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public IEnumerable<PlaylistItem> Items { get; set; }
    public Person Person { get; set; }
    public Guid PersonId { get; set; }
}