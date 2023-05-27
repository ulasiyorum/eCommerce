namespace eCommerce_backend.Dtos.Cart;

public class UpdateCartDto
{
    public int UserId { get; set; }
    public List<int> MovieIds { get; set; }
    public double? PriceAsFixed { get; set; }
    public double? DiscountAsPercentage { get; set; }
}