namespace eCommerce_backend.Dtos.Producer
{
    public class AddProducerDto
    {
        public string ProfilePictureURL { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

        public List<Movie>? Movies { get; set; }
    }
}
