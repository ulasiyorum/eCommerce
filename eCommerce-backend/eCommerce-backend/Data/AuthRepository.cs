using AutoMapper.QueryableExtensions;
using eCommerce_backend.Dtos.User;
using eCommerce_backend.Models;
using eCommerce_backend.Services.TokensService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace eCommerce_backend.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ITokenService tokenService;
        private readonly DataContext context;
        private readonly IConfiguration configuration;

        public AuthRepository(DataContext c, IConfiguration conf, ITokenService ts)
        {
            context = c;
            configuration = conf;
            tokenService = ts;
        }

        public async Task<ServiceResponse<GetUserDto>> Login(string username, string password)
        {
            var response = new ServiceResponse<GetUserDto>();
            var user = await context.Users
                .Include(u => u.Movies)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            

            if(user is null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";
            }
            else
            {
                string refreshToken = tokenService.GenerateRefreshToken(user.Id, user.Username);
                string accessToken = tokenService.GenerateAccessToken(refreshToken);

                response.Data = new GetUserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    OwnedMovies = user.Movies is not null ? user.Movies.Select(u => u.MovieId).ToList() : new List<int>(),
                    RefreshToken = refreshToken,
                    AccessToken = accessToken
                };

            }
            return response;
        }

        public string GetAccessToken(string refresh)
        {
            return tokenService.GenerateAccessToken(refresh);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHas, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHas = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(hash);
            }
        }


        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if(await UserExists(user.Username))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }

            CreatePasswordHash(password, out byte[] passHash, out byte[] passSalt);
            user.PasswordSalt = passSalt;
            user.PasswordHash = passHash;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            response.Data = user.Id;

            return response;

        }

        public async Task<bool> UserExists(string username)
        {
            if (await context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UserUpdateDto update)
        {
            var response = new ServiceResponse<GetUserDto>();
            try
            {
                var user = await context.Users
                    .Include(u => u.Movies)
                    .FirstOrDefaultAsync(u => u.Username == update.Username);

                if (user is null)
                    throw new Exception("User not found");

                user.Movies ??= new List<UserMovies>();
                user.Movies
                    .AddRange(update.OwnedMovies
                    .Select(id => new UserMovies { UserId = user.Id, MovieId = id})
                    .Except(user.Movies));

                user.Movies.RemoveAll(mu => !update.OwnedMovies.Contains(mu.MovieId));

                await context.SaveChangesAsync();

                response.Data = new GetUserDto()
                {
                    Username = user.Username,
                    Id = user.Id,
                    OwnedMovies = user.Movies.Select(um => um.MovieId).ToList()
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
