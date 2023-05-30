using eCommerce_backend.Dtos.MovieDto;

namespace eCommerce_backend.Dtos.Purchase;

public class GetPurchaseDto
{
    public double Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string PurchaseNote { get; set; } = string.Empty;
    public List<GetMoviesDto> Movies { get; set; } = new List<GetMoviesDto>();
    public bool Discount { get; set; } = false;
}