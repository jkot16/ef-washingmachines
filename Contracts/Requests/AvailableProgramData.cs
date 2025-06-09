using System.ComponentModel.DataAnnotations;

namespace Test2S30964JakubKot.Contracts.Requests;

public class AvailableProgramData
{
    [Required]
    public string ProgramName { get; set; } = null!;
    
    [Required]
    public decimal Price { get; set; }
}