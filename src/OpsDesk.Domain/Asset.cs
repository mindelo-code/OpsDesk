namespace OpsDesk.Domain;
public class Asset
{
    public Guid Id { get; private set; }
    public string Tag { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public AssetType Type { get; private set; }

    public DateOnly PurchaseDate { get; private set; }
    public DateOnly? WarrantyEnd { get; private set; }
    public Decimal PurchasePrice { get; private set; }
    public string? Notes { get; private set; }

    public Asset (string tag, string name, AssetType type, DateOnly purchaseDate, Decimal purchasePrice)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(tag);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegative(purchasePrice);

        Id = Guid.NewGuid();
        Tag = tag;
        Name = name;
        Type = type;
        PurchaseDate = purchaseDate;
        PurchasePrice = purchasePrice;
    }

    public void SetWarranty (DateOnly end)
    {
        if (end < PurchaseDate)
            throw new ArgumentException("Warranty cannot end before purchase date.", nameof(end));
        
        WarrantyEnd = end;
    }

    public void SetNotes (string? notes)
    {
        Notes = notes;
    }

    public bool IsUnderWarranty(DateOnly today)
    {
        return WarrantyEnd >= today;
    }

}