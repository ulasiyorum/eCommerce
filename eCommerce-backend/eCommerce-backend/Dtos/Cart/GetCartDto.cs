using eCommerce_backend.Dtos.MovieDto;

namespace eCommerce_backend.Dtos.Cart;

public class GetCartDto
{
    public double Price { get; set; }
    public List<GetMoviesDto> Movies { get; set; }
}