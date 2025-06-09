using Microsoft.AspNetCore.Mvc;
using Test2S30964JakubKot.Services;

namespace Test2S30964JakubKot.Controllers;

[ApiController]
[Route("api/customers")]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchaseController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    
    [HttpGet("{customerId}/purchases")]
    public async Task<IActionResult> GetCustomerPurchases(int customerId, CancellationToken cancellationToken)
    {
        
        
        var result = await _purchaseService.GetCustomerPurchaseAsync(customerId, cancellationToken);
        
        if (result is null)
        {
            return NotFound($"Customer with ID {customerId} not found.");
        }

        return Ok(result);
    }
}