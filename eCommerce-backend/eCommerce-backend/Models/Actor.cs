global using System.ComponentModel.DataAnnotations;

namespace eCommerce_backend.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProfilePictureURL { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<Movie>? Movies { get; set; }
    }
}
