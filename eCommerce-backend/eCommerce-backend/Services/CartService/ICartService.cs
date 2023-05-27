using eCommerce_backend.Dtos.Cart;

namespace eCommerce_backend.Services.CartService;

public interface ICartService
{
    Task<ServiceResponse<GetCartDto>> GetCart(int userId);
    Task<ServiceResponse<GetCartDto>> UpdateCart(UpdateCartDto cart);
    Task<ServiceResponse<GetCartDto>> AddToCart(AddToCartDto cartItem);
    Task<ServiceResponse<GetCartDto>> DeleteFromCart(int userId, int movieId);
    Task<ServiceResponse<GetCartDto>> DeleteCart(int id);
}