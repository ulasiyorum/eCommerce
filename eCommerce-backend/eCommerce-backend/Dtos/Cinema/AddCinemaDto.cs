namespace eCommerce_backend.Dtos.Cinema
{
    public class AddCinemaDto
    {
        public string CinemaLogo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int ServiceRate { get; set; } = 0;

        public List<Movie>? Movies { get; set; }
    }
}
