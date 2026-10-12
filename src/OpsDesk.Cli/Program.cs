using OpsDesk.Domain;

Console.WriteLine($"{OpsDeskInfo.Name} v{OpsDeskInfo.Version}");

var assets = new List<Asset>();
assets.Add(new Asset{Id= Guid.NewGuid(), Tag ="PT-0001", Name = "NB-INF01", Type=AssetType.Laptop, PurchaseDate = new DateOnly(2023,05,15), WarrantyEnd = new DateOnly(2027,05,15), PurchasePrice = 85000, Notes = "Used by IT" });

assets.Add(new Asset{Id= Guid.NewGuid(), Tag ="PT-0002", Name = "PC-FIN01", Type=AssetType.Laptop, PurchaseDate = new DateOnly(2023,05,15), WarrantyEnd = new DateOnly(2026,05,15), PurchasePrice = 85000, Notes = "Used by IT" });

assets.Add(new Asset{Id= Guid.NewGuid(), Tag ="PT-0003", Name = "PR-ESQ01", Type=AssetType.Printer, PurchaseDate = new DateOnly(2023,05,15), PurchasePrice = 85000, Notes = "Used in the MJSV Open Space" });

foreach (var asset in assets)
{
    Console.WriteLine($"Tag: {asset.Tag} Name: {asset.Name} Warranty: {asset.IsUnderWarranty(DateOnly.FromDateTime(DateTime.UtcNow))}");
}

Guid assetId = assets[2].Id;

var ticket = new Ticket {Id = Guid.NewGuid(), AssetId= assetId, CreatedAt=DateTimeOffset.UtcNow, Description="Printer is offline", Priority=TicketPriority.High, Title="Printer"};

Console.WriteLine($"Ticket Title:{ticket.Title}, Description:{ticket.Description} Priority:{ticket.Priority} Asset:{ticket.AssetId} CreatAt:{ticket.CreatedAt}");