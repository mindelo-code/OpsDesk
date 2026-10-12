namespace OpsDesk.Domain;
public class Asset
{
    public Guid Id { get; set; }
    public string Tag { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public AssetType Type { get; set; }

    public DateOnly PurchaseDate { get; set; }
    public DateOnly? WarrantyEnd { get; set; }
    public Decimal PurchasePrice { get; set; }
    public string? Notes { get; set; }

    public bool IsUnderWarranty(DateOnly today)
    {
        return WarrantyEnd >= today;
    }

}