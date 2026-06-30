using OlmsApp.DTOs;
using OlmsApp.Interfaces;
using OlmsApp.Models;
using OlmsApp.Shared;

namespace OlmsApp.Services;

public class AuthService : IAuthService
{
    private readonly List<User> _users = [];

    public OperationResult Register(UserDto userDto)
    {
        if (_users.Any(x => x.UserName == userDto.UserName))
            return OperationResult.Failed("Username already exists.");
        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            UserName = userDto.UserName,
            Password = userDto.Password,
        };
        _users.Add(newUser);
        return OperationResult.Success();
    }

    public OperationResult<Guid> Login(UserDto userDto)
    {
        var user = (_users.FirstOrDefault(x => x.UserName == userDto.UserName && x.Password == userDto.Password));
        if (user == null)
            return OperationResult<Guid>.Failed("Invalid username or password.");
        user.Token = Guid.NewGuid();
        user.ExpireAt = DateTime.UtcNow.AddHours(4);
        return OperationResult<Guid>.Success(user.Token.Value);
    }

    public OperationResult IsValidToken(Guid token)
    {
        var user = _users.FirstOrDefault(x => x.Token == token);
        if (user == null)
            return OperationResult.Failed("Invalid token.");

        return user.ExpireAt < DateTime.UtcNow
            ? OperationResult.Failed("Token has expired.")
            : OperationResult.Success();
    }
}