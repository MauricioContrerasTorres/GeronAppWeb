using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.Common
{
    public class JWTParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJWT(string tokenJWT)
        {
            var claims = new List<Claim>();
            var payload = tokenJWT.Split('.')[1];
            var jsonBytes = ParsearEnBase64SinMargen(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);


            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }

        private static byte[] ParsearEnBase64SinMargen(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;

                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}
