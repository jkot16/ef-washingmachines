using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2S30964JakubKot.Models;

[Table("Washing_Machine")]
public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }

    [Required]
    public decimal MaxWeight { get; set; }

    [Required, MaxLength(100)]
    public string SerialNumber { get; set; } = null!;

    public List<AvailableProgram> AvailablePrograms { get; set; } = new();
}