namespace eCommerce_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public List<UserMovies>? Movies { get; set; }
        
        public List<Purchases> PurchaseList { get; set; } = new List<Purchases>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<MovieComment> Comments { get; set; } = new List<MovieComment>();
        public List<UserFavoriteMovies> FavoriteMoviesList { get; set; }   = new List<UserFavoriteMovies>();
    }
}
