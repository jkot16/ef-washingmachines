using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Test2S30964JakubKot.Models;


[Table("Customer")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    
    
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required, MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }

    public List<PurchaseHistory> Purchases { get; set; } = new();
}