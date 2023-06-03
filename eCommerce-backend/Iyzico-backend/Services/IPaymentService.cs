using eCommerce_backend.Models;
using Iyzico_backend.DTOs;

namespace Iyzico_backend.Services;

public interface IPaymentService
{
    Task<ServiceResponse<PaymentResponseDto>> Pay(StartPaymentDto paymentDto);
}