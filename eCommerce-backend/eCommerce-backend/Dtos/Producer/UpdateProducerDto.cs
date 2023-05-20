namespace eCommerce_backend.Dtos.Producer
{
    public class UpdateProducerDto
    {
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

        public List<int> Movies { get; set; } = new List<int>();
    }
}
