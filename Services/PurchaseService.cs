using Microsoft.EntityFrameworkCore;
using Test2S30964JakubKot.Contracts.Responses;
using Test2S30964JakubKot.Data;

namespace Test2S30964JakubKot.Services;

public class PurchaseService : IPurchaseService
{
    private readonly DBContext _context;

    public PurchaseService(DBContext context)
    {
        _context = context;
    }

    public async Task<PurchaseResponse?> GetCustomerPurchaseAsync(int customerId, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .Include(c => c.Purchases)
            .ThenInclude(p => p.AvailableProgram)
            .ThenInclude(ap => ap.WashingMachine)
            .Include(c => c.Purchases)
            .ThenInclude(p => p.AvailableProgram)
            .ThenInclude(ap => ap.WashingProgram)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken);

        if (customer is null)
        {
            return null;
        }
        

        return new PurchaseResponse
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber =customer.PhoneNumber,
            Purchases = customer.Purchases.Select(ph => new PurchaseEntry
            {
                Date = ph.PurchaseDate,
                Rating = ph.Rating,
                Price = ph.AvailableProgram.Price,
                WashingMachine = new WashingMachineResponse
                {
                    Serial = ph.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight
                },
                Program = new ProgramResponse
                {
                    Name = ph.AvailableProgram.WashingProgram.Name,
                    Duration = ph.AvailableProgram.WashingProgram.DurationMinutes
                }
            }).ToList()
        };
    }
}