using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models
{
    public class UserMovies
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Models.User))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey(nameof(Models.Movie))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
