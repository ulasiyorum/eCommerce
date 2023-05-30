using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models;

public class Purchases
{
    public int Id { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User? User { get; set; }
    
    public double TotalPrice { get; set; }
    public string PurchaseNote { get; set; } = string.Empty;
    
    public List<MoviePurchase> Movies { get; set; } = new List<MoviePurchase>();

    public DateTime PurchaseDate { get; set; } = DateTime.Now;
}