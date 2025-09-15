using AuthServer.Domain.Abstractions;
using AuthServer.Domain.Entities;

namespace AuthServer.Infrastructure.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> _users = new()
    {
        new User("admin", "admin123", "Admin"),
        new User("publisher", "pub123", "Publisher"),
        new User("reader", "read123", "Reader")
    };

    public User? FindByUsername(string username) =>
        _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
}
