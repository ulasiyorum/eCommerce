namespace Iyzico_backend.DTOs;

public class BuyerDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string IdentityNumber { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string Email { get; set; }
    public required string Ip { get; set; }
    public required string RegistrationAddress { get; set; }

}