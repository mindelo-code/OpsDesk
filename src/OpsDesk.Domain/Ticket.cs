namespace OpsDesk.Domain;
public class Ticket
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public TicketPriority Priority { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public Guid? AssetId { get; private set; }
    public TicketStatus Status { get; private set; }
    public DateTimeOffset? ResolvedAt { get; private set; }

    public Ticket (string title, string description, TicketPriority priority, Guid? assetId = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Priority = priority;
        CreatedAt = DateTimeOffset.UtcNow;
        Status = TicketStatus.Open;     
        AssetId = assetId;

    }

    public void Start()
    {
        if (Status != TicketStatus.Open)
            throw new InvalidOperationException($"Cannot start a ticket in status {Status}.");

        Status = TicketStatus.InProgress;
    }

    public void Resolve()
    {
        if (Status != TicketStatus.InProgress)
            throw new InvalidOperationException("Ticket is not in progress.");
        
        Status = TicketStatus.Resolved;
        ResolvedAt = DateTimeOffset.UtcNow;
    }

    public void Reopen()
    {
        if (Status != TicketStatus.Resolved)
            throw new InvalidOperationException("Ticket is not resolved.");
        
        Status = TicketStatus.InProgress;
        ResolvedAt = null;
    }

    public void Close()
    {
        if (Status != TicketStatus.Resolved)
            throw new InvalidOperationException("Ticket is not resolved.");
        
        Status = TicketStatus.Closed;
    }

}