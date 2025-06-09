using Test2S30964JakubKot.Contracts.Responses;

namespace Test2S30964JakubKot.Services;

public interface IPurchaseService
{
    Task<PurchaseResponse?> GetCustomerPurchaseAsync(int customerId, CancellationToken cancellationToken);
}