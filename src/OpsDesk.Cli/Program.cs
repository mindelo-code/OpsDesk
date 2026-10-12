using OpsDesk.Domain;

Console.WriteLine($"{OpsDeskInfo.Name} v{OpsDeskInfo.Version}");

var assets = new List<Asset>();

assets.Add(new Asset("PT-0001", "NB-INF01", AssetType.Laptop, new DateOnly(2023,05,15), 85000 ));

assets.Add(new Asset("PT-0002","PC-FIN01",AssetType.Laptop, new DateOnly(2023,05,15), 85000 ));

assets.Add(new Asset("PT-0003","PR-ESQ01",AssetType.Printer,new DateOnly(2023,05,15), 85000 ));


try
{
    new Asset("PT-0003","XX-XXX01",AssetType.Printer,new DateOnly(2023,05,15), -85000 );
}
catch (Exception err)
{
    Console.WriteLine(err.Message);
}

foreach (var asset in assets)
{
    Console.WriteLine($"Tag: {asset.Tag} Name: {asset.Name} Warranty: {asset.IsUnderWarranty(DateOnly.FromDateTime(DateTime.UtcNow))}");
}

Guid assetId = assets[2].Id;

var ticket = new Ticket ("Printer", "Printer is offline", TicketPriority.High, assetId);

Console.WriteLine($"Ticket Title:{ticket.Title}, Description:{ticket.Description} Priority:{ticket.Priority} Asset:{ticket.AssetId} CreatedAt:{ticket.CreatedAt}");

ticket.Start();
Console.WriteLine($"Status: {ticket.Status}");

ticket.Resolve();
Console.WriteLine($"Status: {ticket.Status}");

ticket.Close();
Console.WriteLine($"Status: {ticket.Status}");

try
{
    ticket.Start();
}
catch (Exception err)
{
    Console.WriteLine(err.Message);
}