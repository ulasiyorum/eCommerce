using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PostTime { get; set; }
        public int Rate { get; set; }

        [ForeignKey(nameof(Models.Movie))]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        [ForeignKey(nameof(Models.User))]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
