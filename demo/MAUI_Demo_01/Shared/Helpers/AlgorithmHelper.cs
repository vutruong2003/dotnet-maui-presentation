using System.Security.Cryptography;
using System.Text;

namespace MAUI_Demo_01.Shared.Helpers;

public static class AlgorithmHelper
{
    public static string ToSha256Hash(this string value)
    {
        using (var sha = SHA256.Create())
        {
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(value));

            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat(b.ToString("x2"));
            }
            return stringBuilder.ToString().ToUpper();
        }
    }

    public static string ToSha512Hash(this string value)
    {
        using (var sha512 = SHA512.Create())
        {
            byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(value));

            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat(b.ToString("x2"));
            }
            return stringBuilder.ToString().ToUpper();
        }
    }

    public static string ToHmacSha512Hash(this string value, string key)
    {
        using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
        {
            byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(value));

            var stringBuilder = new StringBuilder();

            foreach (byte b in hashValue)
            {
                stringBuilder.AppendFormat(b.ToString("x2"));
            }

            return stringBuilder.ToString().ToLower();
        }
    }
}