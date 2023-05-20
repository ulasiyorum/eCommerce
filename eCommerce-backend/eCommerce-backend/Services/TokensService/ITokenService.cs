namespace eCommerce_backend.Services.TokensService
{
    public interface ITokenService
    {
        string GenerateAccessToken(string refreshToken);
        string GenerateRefreshToken(int id, string username);
    }
}
