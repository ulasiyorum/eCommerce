namespace eCommerce_backend.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        public int Id { get; set; }
        public string CinemaLogo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int ServiceRate { get; set; } = 0;

        public List<int> Movies { get; set; } = new List<int>();
    }
}
