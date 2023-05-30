using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models;

public class MoviePurchase
{
    public int Id { get; set; }
    [ForeignKey(nameof(Movie))]
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    [ForeignKey(nameof(Purchases))] 
    public int PurchaseId { get; set; }
    public Purchases? Purchases { get; set; }
}