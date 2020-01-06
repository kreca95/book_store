using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using MongoDb.Data.Models;
using MongoDb.Service.Implementations;
using MongoDb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Service.OAuth
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                IAuthService userService = new AuthService();
                User user = userService.Login(username, password);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("UserID", user.Id)
                    };

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}
