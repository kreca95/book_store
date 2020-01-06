﻿using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using MongoDb.Service.Implementations;
using MongoDb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace authAPI
{
    public class AuthServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService db = new AuthService();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();//
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);


            var user = db.Login(context.UserName,context.Password);

            if (user != null)
            {
                //identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                //identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.Name));
                context.Validated(identity);

            }
            //else if(context.UserName == "user" && context.Password == "user")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            //    identity.AddClaim(new Claim("username", "user"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "kresoUser"));
            //    context.Validated(identity);
            //}
            else
            {
                context.SetError("Invalid grant", "Invalid username or password");
                return;
            }
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            //var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            //var currentClient = context.ClientId;

            //if (originalClient != currentClient)
            //{
            //    context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
            //    return Task.FromResult<object>(null);
            //}

            // Change auth ticket for refresh token requests

            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newClaim = newIdentity.Claims.FirstOrDefault(c => c.Type == "newClaim");
            if (newClaim != null)
            {
                newIdentity.RemoveClaim(newClaim);
            }
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }
}