namespace eCommerce_backend.Dtos.Purchase;

public class AddPurchaseDto
{
    public int UserId { get; set; }
    public List<int> MovieIds { get; set; } = new List<int>();
    public string PurchaseNote { get; set; } = string.Empty;
    public double DiscountAsPercentage { get; set; } = 0;
}