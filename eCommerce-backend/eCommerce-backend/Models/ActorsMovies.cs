using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models
{
    public class ActorsMovies
    {
        [ForeignKey(nameof(Models.Actor))]
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;

        [ForeignKey(nameof(Models.Movie))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
