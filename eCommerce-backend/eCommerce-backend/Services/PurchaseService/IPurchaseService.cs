using eCommerce_backend.Dtos.Purchase;

namespace eCommerce_backend.Services.PurchaseHistoryService;

public interface IPurchaseService
{
    Task<ServiceResponse<List<GetPurchaseDto>>> GetPurchaseHistoryByUserId(int id);
    Task<ServiceResponse<double>> Checkout(AddPurchaseDto purchaseDto);
}