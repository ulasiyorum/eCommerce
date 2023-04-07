using eCommerce_backend.Dtos.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace eCommerce_backend.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        private readonly IConfiguration configuration;
        public AuthRepository(DataContext c, IConfiguration conf)
        {
            context = c;
            configuration = conf;
        }

        public async Task<ServiceResponse<GetUserDto>> Login(string username, string password)
        {
            var response = new ServiceResponse<GetUserDto>();
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            

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
                response.Data = new GetUserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    OwnedMovies = user.OwnedMovies
                };
            }

            return response;
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

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var appSettingsToken = configuration.GetSection("AppSettings:Token").Value;

            if (appSettingsToken is null)
                throw new Exception("AppSettings Token Is Null");

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
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
                var user = await context.Users.FirstOrDefaultAsync(u => u.Username == update.Username);

                if (user is null)
                    throw new Exception("User not found");

                user.OwnedMovies = update.OwnedMovies;
                await context.SaveChangesAsync();

                response.Data = new GetUserDto()
                {
                    Username = user.Username,
                    Id = user.Id,
                    OwnedMovies = user.OwnedMovies
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
