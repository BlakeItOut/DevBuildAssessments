using Microsoft.AspNet.Identity;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(StillWorkingThatList_BlakeShaw.Startup))]

namespace StillWorkingThatList_BlakeShaw
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlakeIdentityPartyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            app.CreatePerOwinContext(() => new IdentityDbContext(connectionString));

            app.CreatePerOwinContext<UserManager<IdentityUser>>((options, context) =>
                new UserManager<IdentityUser>(
                    new UserStore<IdentityUser>(context.Get<IdentityDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Identity/Login"),
            });
        }
    }
}
