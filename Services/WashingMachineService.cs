using Microsoft.EntityFrameworkCore;
using Test2S30964JakubKot.Contracts.Requests;
using Test2S30964JakubKot.Data;
using Test2S30964JakubKot.Models;

namespace Test2S30964JakubKot.Services;

public class WashingMachineService : IWashingMachineService
{
    private readonly DBContext _context;

    public WashingMachineService(DBContext context)
    {
        _context = context;
    }

    public async Task AddWashingMachineAsync(AddWashingMachineRequest request, CancellationToken cancellationToken)
    {
        if (request.WashingMachine.MaxWeight < 8)
        {
            throw new ArgumentException("Max weight has to be at least 8kg.");
        }

        if (await _context.WashingMachines.AnyAsync(w => w.SerialNumber == request.WashingMachine.SerialNumber,
                cancellationToken))
        {
            throw new ArgumentException("Washing machine with same serial number exits.");
        }


        if (request.AvailablePrograms.Any(p => p.Price > 25))
        {
            throw new ArgumentException("One or more programs exceed the allowed price of 25.");
        }
           


        var programNames = request.AvailablePrograms.Select(p => p.ProgramName).ToList();

        var programs = await _context.Programs.Where(p => programNames.Contains(p.Name))
            .ToListAsync(cancellationToken);

        if (programs.Count != request.AvailablePrograms.Count)
        {
            throw new ArgumentException("One or more programs do not exist.");
        }
           

        var machine = new WashingMachine
        {
            SerialNumber = request.WashingMachine.SerialNumber,
            MaxWeight = request.WashingMachine.MaxWeight,
            AvailablePrograms = request.AvailablePrograms.Select(ap =>
            {
                var program = programs.First(p => p.Name == ap.ProgramName);
                return new AvailableProgram
                {
                    ProgramId = program.ProgramId,
                    Price = ap.Price
                };
            }).ToList()
        };

        _context.WashingMachines.Add(machine);
        await _context.SaveChangesAsync(cancellationToken);
    
    }
}