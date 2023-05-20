using eCommerce_backend.Models;
using System.Formats.Asn1;

namespace eCommerce_backend.Dtos.Actor
{
    public class UpdateActorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProfilePictureURL { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<int> Movies { get; set; } = new List<int>();
    }
}
