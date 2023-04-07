using System.ComponentModel.DataAnnotations.Schema;
using eCommerce_backend.Models;
namespace eCommerce_backend.Dtos.MovieDto
{
    public class GetMoviesDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public MovieType Genre { get; set; }
        public DateTime DatePublished { get; set; }

        public List<int>? Actors { get; set; }

        public int CinemaId { get; set; }

        public int ProducerId { get; set; }
    }
}
