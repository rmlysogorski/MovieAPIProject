using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieAPIProject.Startup))]
namespace MovieAPIProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
