using Test2S30964JakubKot.Contracts.Requests;

namespace Test2S30964JakubKot.Services;

public interface IWashingMachineService
{
    Task AddWashingMachineAsync(AddWashingMachineRequest request, CancellationToken cancellationToken);
}