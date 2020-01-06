using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(authAPI.Startup))]

namespace authAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var client_id = "public";
            var myProvider = new AuthServerProvider();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = myProvider,
                RefreshTokenProvider = new RefreshTokenProvider()

            };

            app.UseOAuthAuthorizationServer(options);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            HttpConfiguration config = new HttpConfiguration();
            MongoDb.WebApiConfig.Register(config);
        }
        private void CreateRefreshToken(AuthenticationTokenCreateContext context)
        {
            context.SetToken(context.SerializeTicket());
        }

        private void ReceiveRefreshToken(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }
}