namespace Iyzico_backend.DTOs;

public class PaymentResponseDto
{
    public string PayWithIyzicoPageUrl { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public int TokenExpireTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string ErrorGroup { get; set; } = string.Empty;
    public string Locale { get; set; } = string.Empty;
    public int SystemTime { get; set; }
    public int ConversationId { get; set; }
}