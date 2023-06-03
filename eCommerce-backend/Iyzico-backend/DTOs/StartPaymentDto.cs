using Iyzipay.Model;

namespace Iyzico_backend.DTOs;

public class StartPaymentDto
{
    public string? Locale { get; set; }
    public string? ConversationId { get; set; }
    public required decimal Price { get; set; }
    public required decimal PaidPrice { get; set; }
    public string Currency { get; set; } = "TRY";
    public string? BasketId { get; set; }
    public string PaymentGroup { get; set; } = "PRODUCT";
    public string CallbackUrl { get; set; } = "https://verdantdev.co";
    public required BuyerDto Buyer { get; set; }
    public required BillingAdressDto BillingAddress { get; set; }
    public required ShippingAdressDto ShippingAdress { get; set; }
    public required List<BasketItem> BasketItems { get; set; }
}