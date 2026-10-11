using OpsDesk.Domain;

Console.WriteLine($"{OpsDeskInfo.Name} v{OpsDeskInfo.Version}");

var assets = new List<Asset>();
assets.Add(new Asset{Id= Guid.NewGuid(), Tag ="PT-0001", Name = "NB-INF01", Type=AssetType.Laptop, PurchaseDate = new DateOnly(2023,05,15), WarrantyEnd = new DateOnly(2027,05,15), PurchasePrice = 85000, Notes = "Used by IT" });

assets.Add(new Asset{Id= Guid.NewGuid(), Tag ="PT-0002", Name = "PC-FIN01", Type=AssetType.Laptop, PurchaseDate = new DateOnly(2023,05,15), WarrantyEnd = new DateOnly(2026,05,15), PurchasePrice = 85000, Notes = "Used by IT" });

assets.Add(new Asset{Id= Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), Tag ="PT-0003", Name = "PR-ESQ01", Type=AssetType.Laptop, PurchaseDate = new DateOnly(2023,05,15), PurchasePrice = 85000, Notes = "Used in the MJSV Open Space" });

foreach (var ass in assets)
{
    Console.WriteLine($"Tag: {ass.Tag} Name: {ass.Name} Warranty: {ass.IsUnderWarranty(new DateOnly())}");
}

var ticket = new Ticket {Id = Guid.NewGuid(), AssetId= Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), CreatAt=new DateTime(2026,10,05,12,10,25), Description="Printer is offline", Priority=TicketPriority.Higth, Title="Printer"};

Console.WriteLine($"Ticket Title:{ticket.Title}, Description:{ticket.Description} Type:{ticket.GetType} Priority:{ticket.Priority} Asset:{ticket.AssetId} CreatAt:{ticket.CreatAt}");