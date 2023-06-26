using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TesteVagaDevPleno.Modules.UserModule.Entity;

namespace TesteVagaDevPleno.Modules.AuthModule.Provider
{
    public class TokenProvider
    {
        public static object GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.id),
                     new Claim("is_enabled", user.is_enabled.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokeString = tokenHandler.WriteToken(token);

            return new      
            {
                token = tokeString
            };

        }
    }
}
