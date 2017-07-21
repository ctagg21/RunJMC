using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RunJMC.Startup))]
namespace RunJMC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
