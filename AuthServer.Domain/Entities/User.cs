namespace AuthServer.Domain.Entities;

public class User
{
    public string Username { get; }
    public string Password { get; } 
    public string[] Roles { get; }

    public User(string username, string password, params string[] roles)
    {
        Username = username;
        Password = password;
        Roles = roles;
    }
}
