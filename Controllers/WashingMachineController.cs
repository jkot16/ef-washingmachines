using Microsoft.AspNetCore.Mvc;
using Test2S30964JakubKot.Contracts.Requests;
using Test2S30964JakubKot.Services;

namespace Test2S30964JakubKot.Controllers;

[ApiController]
[Route("api/washing-machines")]
public class WashingMachinesController : ControllerBase
{
    private readonly IWashingMachineService _service;

    public WashingMachinesController(IWashingMachineService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddMachine([FromBody] AddWashingMachineRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _service.AddWashingMachineAsync(request, cancellationToken);
            
            // return some text and serial so its not completely empty
            return CreatedAtAction(nameof(AddMachine), new { serial = request.WashingMachine.SerialNumber }, "Washing machine added");

        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

}