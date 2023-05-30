using eCommerce_backend.Dtos.MovieDto;
using eCommerce_backend.Dtos.Purchase;

namespace eCommerce_backend.Services.PurchaseHistoryService;

public class PurchaseService : IPurchaseService
{
    private readonly DataContext _context;
    
    public PurchaseService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<GetPurchaseDto>>> GetPurchaseHistoryByUserId(int id)
    {
        var response = new ServiceResponse<List<GetPurchaseDto>>();

        try
        {
            var purchases = await _context.Purchases
                .Include(p => p.Movies).ThenInclude(m => m.Movie)
                .Where(p => p.UserId == id).ToListAsync();

            if (purchases is null)
                purchases = new List<Purchases>();

            response.Data = purchases.Select(p => new GetPurchaseDto
            {
                PurchaseDate = p.PurchaseDate,
                PurchaseNote = p.PurchaseNote,
                Movies = p.Movies.Select(m => new GetMoviesDto
                {
                    Id = m.MovieId,
                    Title = m.Movie.Title,
                    Description = m.Movie.Description,
                    Price = m.Movie.Price,
                    ImageURL = m.Movie.ImageURL,
                    DatePublished = m.Movie.DatePublished,
                }).ToList()
            }).ToList();

        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }

    public async Task<ServiceResponse<double>> Checkout(AddPurchaseDto purchaseDto)
    {
        var response = new ServiceResponse<double>();
        try
        {

            var purchase = new Purchases
            {
                UserId = purchaseDto.UserId,
                PurchaseNote = purchaseDto.PurchaseNote,
                PurchaseDate = DateTime.Now,
            };
            _context.Purchases.Add(purchase);
            
            await _context.SaveChangesAsync();
            
            var movies = await _context.Movies.Where(m => purchaseDto.MovieIds.Contains(m.Id)).ToListAsync();

            double totalPrice = 0;
            
            movies.ForEach(m =>
            {
                totalPrice += m.Price - (m.Price * purchaseDto.DiscountAsPercentage);
                
                var moviePurchase = new MoviePurchase
                {
                    MovieId = m.Id,
                    PurchaseId = purchase.Id
                };
                
                _context.MoviesPurchases.Add(moviePurchase);
            });
            
            await _context.SaveChangesAsync();
            
            response.Data = totalPrice;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }
}