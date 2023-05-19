namespace eCommerce_backend.Models
{
    public interface IComment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public DateTime PostTime { get; set; }
        public int Rate { get; set; }
    }
}
