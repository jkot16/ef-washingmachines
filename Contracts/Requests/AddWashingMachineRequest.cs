using System.ComponentModel.DataAnnotations;

namespace Test2S30964JakubKot.Contracts.Requests;

public class AddWashingMachineRequest
{
    [Required]
    public WashingMachineData WashingMachine { get; set; } = null!;
    
    [Required, MinLength(1)]
    public List<AvailableProgramData> AvailablePrograms { get; set; } = new();

}