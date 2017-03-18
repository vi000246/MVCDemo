using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YDemo.Startup))]
namespace YDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
