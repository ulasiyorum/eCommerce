using eCommerce_backend.Models;
using Iyzipay.Model;

namespace Iyzico_backend.Services;

public interface IBasketItemService
{
    Task<ServiceResponse<List<BasketItem>>> GetBasketItems(List<int> movieIds);
}