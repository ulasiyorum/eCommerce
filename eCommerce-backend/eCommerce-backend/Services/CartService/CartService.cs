using eCommerce_backend.Dtos.Cart;
using eCommerce_backend.Dtos.MovieDto;

namespace eCommerce_backend.Services.CartService;

public class CartService : ICartService
{
    private readonly DataContext _context;

    public CartService(DataContext context)
    {
        _context = context;        
    }
    
    public async Task<ServiceResponse<GetCartDto>> GetCart(int userId)
    {
        var response = new ServiceResponse<GetCartDto>();
        try
        {
            var cart = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Movie)
                .Include(ci => ci.Movie.Actors)
                .ToListAsync();
            
            if (cart is null)
                throw new Exception("User Id:" + userId + " does not have anything on their card.");

            response.Data = new GetCartDto()
            {
                Price =  cart.Sum(ci => ci.Movie.Price),
                Movies = cart.Select(ci => new GetMoviesDto
                {
                    CinemaId = ci.Movie.CinemaId,
                    Id = ci.Movie.Id,
                    Actors = ci.Movie.Actors.Select(a => a.ActorId).ToList(),
                    Description = ci.Movie.Description,
                    Genre = ci.Movie.Genre,
                    Title = ci.Movie.Title,
                    Price = ci.Movie.Price,
                    DatePublished = ci.Movie.DatePublished,
                    ProducerId = ci.Movie.ProducerId,
                    ImageURL = ci.Movie.ImageURL
                }).ToList(),
            };
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }

    public async Task<ServiceResponse<GetCartDto>> UpdateCart(UpdateCartDto cart)
    {
        var response = new ServiceResponse<GetCartDto>();
        try
        {
            var cartItems = await _context.CartItems
                .Where(ci => ci.UserId == cart.UserId)
                .Include(ci => ci.Movie)
                .Include(ci => ci.Movie.Actors)
                .ToListAsync();

            if (cartItems.Count == 0)
                cartItems = new List<CartItem>();

            await _context.Movies.ForEachAsync((value) =>
            {
                if (!cart.MovieIds.Contains(value.Id))
                    throw new Exception("Movie with ID " + value.Id + " does not exist in the database.");
            });

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == cart.UserId);

            if (user is null)
                throw new Exception("User with ID " + cart.UserId + " does not exist in the database.");

            user.CartItems.AddRange(cart.MovieIds.Select(m => new CartItem
            {
                UserId = cart.UserId,
                MovieId = m
            }).Except(user.CartItems));

            user.CartItems.RemoveAll(item => !cart.MovieIds.Contains(item.MovieId));
            
            cartItems.AddRange(cart.MovieIds.Select(m => new CartItem
            {
                UserId = cart.UserId,
                MovieId = m
            }).Except(cartItems));
            
            cartItems.RemoveAll(item => !cart.MovieIds.Contains(item.MovieId));

            await _context.SaveChangesAsync();

            response.Data = new GetCartDto
            {
                Movies = cartItems.Select(ci => new GetMoviesDto
                {
                    CinemaId = ci.Movie.CinemaId,
                    Id = ci.Movie.Id,
                    Actors = ci.Movie.Actors.Select(a => a.ActorId).ToList(),
                    Description = ci.Movie.Description,
                    Genre = ci.Movie.Genre,
                    Title = ci.Movie.Title,
                    Price = ci.Movie.Price,
                    DatePublished = ci.Movie.DatePublished,
                    ProducerId = ci.Movie.ProducerId,
                    ImageURL = ci.Movie.ImageURL
                }).ToList(),
                Price = cart.PriceAsFixed ?? cartItems.Sum(ci => ci.Movie.Price)
            };

            if (cart.DiscountAsPercentage is not null)
            {
                response.Data.Price -= response.Data.Price * (cart.DiscountAsPercentage.Value / 100);
            }
            
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }

    public async Task<ServiceResponse<GetCartDto>> AddToCart(AddToCartDto cartItem)
    {
        var response = new ServiceResponse<GetCartDto>();
        try
        {
            var cart = await _context.CartItems
                .Include(ci => ci.Movie)
                .Include(ci => ci.Movie.Actors)
                .Where(ci => ci.UserId == cartItem.UserId)
                .ToListAsync();

            if (cart.Count == 0)
                cart = new List<CartItem>();

            var movie = await _context.Movies
                .Include(m => m.Cart)
                .FirstOrDefaultAsync(m => m.Id == cartItem.MovieId);

            if (movie is null)
                throw new Exception("Movie with ID: " + cartItem.MovieId + " does not exist in the database.");
            
            var user = await _context.Users
                .Include(u => u.CartItems)
                .FirstOrDefaultAsync(u => u.Id == cartItem.UserId);

            if (user is null)
                throw new Exception("User with ID: " + cartItem.UserId + " does not exist in the database.");

            var item = new CartItem
            {
                UserId = cartItem.UserId,
                MovieId = cartItem.MovieId
            };
            
            user.CartItems.Add(item);
            movie.Cart.Add(item);
            cart.Add(item);

            await _context.SaveChangesAsync();

            response.Data = new GetCartDto
            {
                Movies = cart.Select(ci => new GetMoviesDto
                {
                    CinemaId = ci.Movie.CinemaId,
                    Id = ci.Movie.Id,
                    Actors = ci.Movie.Actors.Select(a => a.ActorId).ToList(),
                    Description = ci.Movie.Description,
                    Genre = ci.Movie.Genre,
                    Title = ci.Movie.Title,
                    Price = ci.Movie.Price,
                    DatePublished = ci.Movie.DatePublished,
                    ProducerId = ci.Movie.ProducerId,
                    ImageURL = ci.Movie.ImageURL
                }).ToList(),
                Price = cart.Sum(ci => ci.Movie.Price)
            };
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        return response;
    }

    public async Task<ServiceResponse<GetCartDto>> DeleteFromCart(int userId, int movieId)
    {
        var response = new ServiceResponse<GetCartDto>();
        try
        {
            var cart = _context.CartItems
                .Include(ci => ci.Movie)
                .Include(ci => ci.Movie.Actors)
                .Where(ci => ci.MovieId == movieId && ci.UserId == userId)
                .ToList();

            if (cart is null)
                throw new Exception("Movie Id:" + movieId + " does not exist in the cart.");

            var item = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.MovieId == movieId);

            if (item is null)
                throw new Exception("Movie Id:" + movieId + " does not exist in the cart.");
            
            _context.CartItems.Remove(item);
            
            await _context.SaveChangesAsync();

            response.Data = new GetCartDto
            {
                Movies = cart.Select(ci => new GetMoviesDto
                {
                    CinemaId = ci.Movie.CinemaId,
                    Id = ci.Movie.Id,
                    Actors = ci.Movie.Actors.Select(a => a.ActorId).ToList(),
                    Description = ci.Movie.Description,
                    Genre = ci.Movie.Genre,
                    Title = ci.Movie.Title,
                    Price = ci.Movie.Price,
                    DatePublished = ci.Movie.DatePublished,
                    ProducerId = ci.Movie.ProducerId,
                    ImageURL = ci.Movie.ImageURL
                }).ToList(),
                Price = cart.Sum(ci => ci.Movie.Price)
            };
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }

    public async Task<ServiceResponse<GetCartDto>> DeleteCart(int id)
    {
        var response = new ServiceResponse<GetCartDto>();
        try
        {
            var cart = await _context.CartItems
                .Where(ci => ci.UserId == id).ToListAsync();
            
            if (cart is null)
                throw new Exception("Cart Id:" + id + " does not exist.");
            
            _context.CartItems.RemoveRange(cart);
            
            await _context.SaveChangesAsync();
            
            response.Data = new GetCartDto
            {
                Movies = new List<GetMoviesDto>(),
                Price = 0
            };
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }
}