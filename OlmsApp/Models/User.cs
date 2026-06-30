namespace OlmsApp.Models;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Guid? Token { get; set; }
    public DateTime? ExpireAt {get; set;}

}