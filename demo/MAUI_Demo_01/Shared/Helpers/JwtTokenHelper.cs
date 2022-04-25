using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MAUI_Demo_01.Shared.Helpers;

public class JwtTokenHelper
{
    public static bool IsValid(string token, TokenValidationParameters tokenValidationParameters)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return false;
        }

        var handler = new JwtSecurityTokenHandler();

        try
        {
            handler.ValidateToken(token, tokenValidationParameters, out _);

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public static bool TryReadTokenPayload(string token, TokenValidationParameters validationParameters, out JwtPayload tokenPayload)
    {
        if (!IsValid(token, validationParameters))
        {
            tokenPayload = null;
            return false;
        }

        var handler = new JwtSecurityTokenHandler();

        var jwtToken = handler.ReadJwtToken(token);

        tokenPayload = JwtPayload.Base64UrlDeserialize(jwtToken.EncodedPayload);

        return tokenPayload?.Keys.Any() == true;
    }

    public static bool TryReadTokenPayload(string token, out JwtPayload tokenPayload)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token);

            tokenPayload = JwtPayload.Base64UrlDeserialize(jwtToken.EncodedPayload);

            return tokenPayload?.Keys.Any() == true;
        }
        catch
        {
            tokenPayload = null;
            return false;
        }
    }

    public static string GenerateRefreshToken()
    {
        var bytes = new byte[32];
        using (var random = RandomNumberGenerator.Create())
        {
            random.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }

    public static ClaimsPrincipal GetPrincipalFromToken(string token, TokenValidationParameters tokenValidationParameters)
    {
        bool canGetPrincipal = string.IsNullOrWhiteSpace(token) || tokenValidationParameters == null;

        if (!canGetPrincipal)
        {
            throw new Exception("Can't get principal out of empty token or empty validation parameters");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }

    public static SigningCredentials GetSigningCredential(string secretKey)
    {
        return new SigningCredentials(GetSymmetricKeyFromSecretKey(secretKey), SecurityAlgorithms.HmacSha256Signature);
    }

    public static SymmetricSecurityKey GetSymmetricKeyFromSecretKey(string tokenSecretKey)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecretKey));

        return securityKey;
    }

    public static bool IsTokenExpire(string token, TokenValidationParameters tokenValidationParameters)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return true;
        }

        long? expireEpochTime = GetPayloadValueByKey<long?>(token, tokenValidationParameters, JwtRegisteredClaimNames.Exp);

        if (!expireEpochTime.HasValue)
        {
            return false;
        }

        var expireOn = DateTimeHelpers.FromUnixTimeStampToDateTime((long)expireEpochTime.Value);

        var isExpired = expireOn <= DateTime.UtcNow;

        return isExpired;
    }

    public static object GetPayloadValueByKey(string token, TokenValidationParameters tokenValidationParameters, string key)
    {
        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(key))
        {
            return null;
        }

        if (!TryReadTokenPayload(token, tokenValidationParameters, out var tokenPayload))
        {
            return null;
        }

        foreach (var tokenKey in tokenPayload.Keys)
        {
            if (!string.Equals(tokenKey, key, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            return tokenPayload[tokenKey];
        }

        return null;
    }

    public static T GetPayloadValueByKey<T>(string token, TokenValidationParameters tokenValidationParameters, string key)
    {
        var data = GetPayloadValueByKey(token, tokenValidationParameters, key);

        if (data == null)
        {
            return default(T);
        }

        //doesn't seem to work when unboxing to int32 from int64, so i use json converter instead
        //return (T)(object)data;

        var jsonString = JsonSerializer.Serialize(data);

        return JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions(JsonSerializerDefaults.Web));
    }

    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];

        var jsonBytes = ParseBase64WithoutPadding(payload);

        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
        return claims;
    }
    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}