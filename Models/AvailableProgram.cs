using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2S30964JakubKot.Models;


[Table("Available_Program")]
public class AvailableProgram
{
    
    [Key]
    public int AvailableProgramId { get; set; }
    
    public int WashingMachineId { get; set; }
    
    [ForeignKey(nameof(WashingMachineId))]
    public WashingMachine WashingMachine { get; set; } = null!;

    public int ProgramId { get; set; }
    
    [ForeignKey(nameof(ProgramId))]
    public WashingProgram WashingProgram { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    public List<PurchaseHistory> PurchaseHistories { get; set; } = new();
}