using AuthServer.Domain.Entities;

namespace AuthServer.Application.Auth;

public interface IAuthService
{
    LoginResult Login(User user, string username, string password);
}