namespace MAUI_Demo_01.Services.Contracts;

public interface IAuthService
{
    Task<string> GetToken();

    Task SetToken(string token);

    Task<UserClaim> GetClaims();

    Task RemoveToken();
}