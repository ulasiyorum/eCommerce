using eCommerce_backend.Dtos.MovieDto;
using eCommerce_backend.Services.FavoriteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_backend.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteService _service;

    public FavoriteController(IFavoriteService service)
    {
        _service = service;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<GetMoviesDto>>>> GetFavoriteMoviesByUserId(int id)
    {
        return Ok(await _service.GetFavoriteMoviesByUserId(id));
    }
    
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetMoviesDto>>> Add(AddFavoriteDto favoriteDto)
    {
        return Ok(await _service.Add(favoriteDto));
    }
    
    [HttpDelete("{userId}/{movieId}")]
    public async Task<ActionResult<ServiceResponse<GetMoviesDto>>> Delete(int userId,int movieId)
    {
        return Ok(await _service.Delete(userId,movieId));
    }
}