using System.Text.Json.Serialization;

namespace eCommerce_backend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MovieType
    {
        Action = 0,
        Horror = 1,
        Thriller = 2,
        Comedy = 3,
        Drama = 4,
        ScienceFiction = 5,
        Documentary = 6
    }
}
