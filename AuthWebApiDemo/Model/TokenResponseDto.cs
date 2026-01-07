namespace AuthWebApiDemo.Model;

public class TokenResponseDto
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}