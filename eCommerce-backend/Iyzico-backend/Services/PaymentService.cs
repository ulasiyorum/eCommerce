using eCommerce_backend.Models;
using Iyzico_backend.DTOs;

namespace Iyzico_backend.Services;

public class PaymentService : IPaymentService
{
    public async Task<ServiceResponse<PaymentResponseDto>> Pay(StartPaymentDto paymentDto)
    {
        var response = new ServiceResponse<PaymentResponseDto>();
        try
        {
                
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Success = false;
        }

        return response;
    }
}