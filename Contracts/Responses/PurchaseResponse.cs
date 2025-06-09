namespace Test2S30964JakubKot.Contracts.Responses;

public class PurchaseResponse
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public List<PurchaseEntry> Purchases { get; set; } = new();
}