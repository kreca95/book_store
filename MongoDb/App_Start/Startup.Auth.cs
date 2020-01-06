using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using MongoDb.Service.OAuth;
using Owin;
using System;

public partial class Startup
{
    public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

    static Startup()
    {
        OAuthOptions = new OAuthAuthorizationServerOptions
        {
            TokenEndpointPath = new PathString("/Token"),
            Provider = new OAuthAppProvider(),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
            AllowInsecureHttp = true
        };

    }

    public void ConfigureAuth(IAppBuilder app)
    {
        app.UseOAuthBearerTokens(OAuthOptions);
        app.UseOAuthAuthorizationServer(OAuthOptions);

    }
}
