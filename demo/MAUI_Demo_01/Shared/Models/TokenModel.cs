using MAUI_Demo_01.Shared.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace MAUI_Demo_01.Shared.Models
{

    public class TokenModel
    {
        public string Scheme { get; } = "Bearer";

        public long ExpiryDateUtc { get; }

        public string AccessToken { get; set; }

        public TokenModel(string token, DateTime expiryDate)
        {
            AccessToken = token;
            ExpiryDateUtc = DateTimeHelpers.DateTimeToUnixTimestamp(expiryDate);
        }

        public TokenModel(string token, DateTime expiryDate, string scheme)
        {
            AccessToken = token;
            ExpiryDateUtc = DateTimeHelpers.DateTimeToUnixTimestamp(expiryDate);
            Scheme = scheme;
        }

        public TokenModel(string accessToken, TokenValidationParameters tokenValidationParameters)
        {
            AccessToken = accessToken;

            var ExpiryDateUtc = JwtTokenHelper.GetPayloadValueByKey<long>(accessToken, tokenValidationParameters, JwtRegisteredClaimNames.Exp);
        }
    }

    public class TokenClaimsModel
    {
        public string UserId { get; set; }
    }
}