using AuthServer.Domain.Entities;

namespace AuthServer.Domain.Abstractions;

public interface IUserRepository
{
    User? FindByUsername(string username);
}
