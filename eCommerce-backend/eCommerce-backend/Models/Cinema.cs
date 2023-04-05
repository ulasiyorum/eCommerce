namespace eCommerce_backend.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string CinemaLogo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int ServiceRate { get; set; } = 0;
    }
}
