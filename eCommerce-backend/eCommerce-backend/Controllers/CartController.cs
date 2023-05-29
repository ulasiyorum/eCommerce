using eCommerce_backend.Dtos.Cart;
using eCommerce_backend.Services.CartService;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce_backend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _service;

    public CartController(ICartService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCartDto>>> Get(int id)
    {
        return Ok(await _service.GetCart(id));
    }
    
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetCartDto>>> AddToCart(AddToCartDto cartItem)
    {
        return Ok(await _service.AddToCart(cartItem));
    }
    
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<GetCartDto>>> UpdateCart(UpdateCartDto cart)
    {
        return Ok(await _service.UpdateCart(cart));
    }
    
    [HttpDelete("{userId}")]
    public async Task<ActionResult<ServiceResponse<GetCartDto>>> DeleteCart(int userId)
    {
        return Ok(await _service.DeleteCart(userId));
    }
    
    [HttpDelete("{userId}/{movieId}")]
    public async Task<ActionResult<ServiceResponse<GetCartDto>>> DeleteFromCart(int userId, int movieId)
    {
        return Ok(await _service.DeleteFromCart(userId, movieId));
    }
}