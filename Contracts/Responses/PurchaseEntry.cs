namespace Test2S30964JakubKot.Contracts.Responses;

public class PurchaseEntry
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public decimal Price { get; set; }
    public WashingMachineResponse WashingMachine { get; set; } = null!;
    public ProgramResponse Program { get; set; } = null!;
}