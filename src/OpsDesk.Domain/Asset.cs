namespace OpsDesk.Domain;
public class Asset
{
    public Guid Id;
    public string Tag;
    public string Name;
    public AssetType Type;

    public DateOnly PurchaseDate;
    public DateOnly? WarrantyEnd;
    public Decimal PurchasePrice;
    public string? Notes;

    public bool IsUnderWarranty(DateOnly today)
    {
        return WarrantyEnd <= today ? true : false;
    }

}