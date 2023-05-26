using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models;

public class UserFavoriteMovies
{
    public int Id { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }
    [ForeignKey(nameof(Movie))]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}