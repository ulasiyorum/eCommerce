using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public MovieType Genre { get; set; }
        public DateTime DatePublished { get; set; }

        public List<Actor>? Actors { get; set; }

        public int CinemaId { get; set; }

        public int ProducerId { get; set; }

    }
}
