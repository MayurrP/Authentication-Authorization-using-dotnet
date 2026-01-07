namespace AuthWebApiDemo.Entites;

public class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Roles { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime RefreshTokenExpiry { get; set; }
}   