namespace MAUI_Demo_01.Services;

public class AuthService : IAuthService
{
    private UserClaim _userClaims;

    public async Task<UserClaim> GetClaims()
    {
        if (_userClaims is not null)
        {
            return _userClaims;
        }

        var token = await GetToken();

        if (string.IsNullOrEmpty(token))
        {
            return null;
        }

        if (JwtTokenHelper.TryReadTokenPayload(token, out var tokenPayload))
        {
            _userClaims = new UserClaim
            {
                Email = tokenPayload[ClaimName.Email]?.ToString() ?? "",
                Id = tokenPayload[ClaimName.UserId]?.ToString() ?? "",
                Name = tokenPayload[ClaimName.Name]?.ToString() ?? "",
                Exp = tokenPayload[ClaimName.Exp]?.ToString() ?? "",
            };
        }

        return _userClaims;
    }

    public Task<string> GetToken()
    {
        return Task.FromResult(GlobalConfig.AppToken);
    }

    public Task RemoveToken()
    {
        GlobalConfig.AppToken = "";

        return Task.CompletedTask;
    }

    public Task SetToken(string token)
    {
        GlobalConfig.AppToken = token;

        return Task.CompletedTask;
    }
}