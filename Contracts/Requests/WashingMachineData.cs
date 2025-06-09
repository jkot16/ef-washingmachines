using System.ComponentModel.DataAnnotations;

namespace Test2S30964JakubKot.Contracts.Requests;

public class WashingMachineData
{
    [Required]
    public decimal MaxWeight { get; set; }
    
    [Required]
    public string SerialNumber { get; set; } = null!;
}