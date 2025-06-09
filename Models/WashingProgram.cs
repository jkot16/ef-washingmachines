using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Test2S30964JakubKot.Models;


[Table("Program")]
public class WashingProgram
{
    
    [Key]
    public int ProgramId { get; set; }

    
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;
    [Required]
    public int DurationMinutes { get; set; }
    
    [Required]
    public int TemperatureCelsius { get; set; }

    public List<AvailableProgram> Programs { get; set; } = new();
}