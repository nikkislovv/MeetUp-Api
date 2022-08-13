using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Server.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "Server";
        public const string AUDIENCE = "Client";
        const string KEY = "secretKey12345678910";  
        public const int LIFETIME = 60; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
