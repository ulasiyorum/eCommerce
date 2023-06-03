using eCommerce_backend.Models;
using Iyzipay.Model;

namespace Iyzico_backend.Services;

public class BasketItemService : IBasketItemService
{
    public Task<ServiceResponse<List<BasketItem>>> GetBasketItems(List<int> movieIds)
    {
        throw new NotImplementedException();
    }
}