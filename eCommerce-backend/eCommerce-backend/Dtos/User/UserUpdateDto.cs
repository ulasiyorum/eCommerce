namespace eCommerce_backend.Dtos.User
{
    public class UserUpdateDto
    {
        public string Username { get; set; } = string.Empty;
        public List<int> OwnedMovies { get; set; } = new List<int>();
    }
}
