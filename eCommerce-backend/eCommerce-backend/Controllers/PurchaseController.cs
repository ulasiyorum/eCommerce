using eCommerce_backend.Dtos.Purchase;
using eCommerce_backend.Services.PurchaseHistoryService;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_backend.Controllers;

public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _service;

    public PurchaseController(IPurchaseService service)
    {
        _service = service;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<GetPurchaseDto>>>> GetUserPurchases(int id)
    {
        return Ok(await _service.GetPurchaseHistoryByUserId(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<double>>> Checkout(AddPurchaseDto purchase)
    {
        return Ok(await _service.Checkout(purchase));
    }
}