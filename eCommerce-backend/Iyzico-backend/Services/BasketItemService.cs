using System.Globalization;
using eCommerce_backend.Data;
using eCommerce_backend.Models;
using Iyzipay.Model;
using Microsoft.EntityFrameworkCore;

namespace Iyzico_backend.Services;

public class BasketItemService : IBasketItemService
{
    private readonly DataContext _context;
    
    public BasketItemService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<BasketItem>>> GetBasketItems(List<int> movieIds)
    {
        var response = new ServiceResponse<List<BasketItem>>();
        try
        {
            var movies = await _context.Movies.Where(m => movieIds.Contains(m.Id)).ToListAsync();
            
            response.Data = movies.Select(m => new BasketItem
            {
                Id = m.Id.ToString(),
                Name = m.Title,
                Category1 = m.Genre.ToString(),
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = m.Price.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Success = false;
        }

        return response;
    }
}