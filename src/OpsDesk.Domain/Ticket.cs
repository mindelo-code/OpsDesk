namespace OpsDesk.Domain;
public class Ticket
{
    public Guid Id;
    public string Title;
    public string Description;
    public TicketPriority Priority;
    public DateTimeOffset CreatAt;
    public Guid? AssetId;
}