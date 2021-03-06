namespace Synword.Application.Utility.Token.DTOs;

public class TokenDto
{
    public TokenDto(
        string accessToken,
        string refreshToken
        )
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
    public string AccessToken { get; }
    public string RefreshToken { get; }
}
