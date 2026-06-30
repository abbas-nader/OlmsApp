using OlmsApp.DTOs;
using OlmsApp.Shared;

namespace OlmsApp.Interfaces;

public interface IAuthService
{
    public OperationResult Register(UserDto user);
    public OperationResult<Guid> Login(UserDto user);
    public OperationResult IsValidToken(Guid token); 
}