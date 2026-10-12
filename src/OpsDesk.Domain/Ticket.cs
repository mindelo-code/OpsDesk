namespace OpsDesk.Domain;
public class Ticket
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid? AssetId { get; set; }
}