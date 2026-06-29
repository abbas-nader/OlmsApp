namespace OlmsApp.Models;

public class Patient
{
    public Guid  Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string NationalCode { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}