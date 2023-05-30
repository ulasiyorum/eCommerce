using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public MovieType Genre { get; set; }
        public DateTime DatePublished { get; set; }
        
        public List<UserFavoriteMovies> UserFavoriteMoviesList { get; set; } = new List<UserFavoriteMovies>();
        public List<ActorsMovies> Actors { get; set; } = new List<ActorsMovies>();
        public List<MoviePurchase> Purchases { get; set; } = new List<MoviePurchase>();
        public List<UserMovies> Users { get; set; } = new List<UserMovies>();
        public List<CartItem> Cart { get; set; } = new List<CartItem>();

        public List<MovieComment> Comments { get; set; } = new List<MovieComment>();

        [ForeignKey(nameof(Models.Cinema))]
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }

        [ForeignKey(nameof(Models.Producer))]
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }

    }
}
