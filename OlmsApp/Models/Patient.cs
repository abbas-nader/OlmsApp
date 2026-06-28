namespace OlmsApp.Models;

public class Patient
{
    public int  Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string NationalCode { get; set; } = null!;
    public bool IsActive { get; set; }
}