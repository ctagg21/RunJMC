using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RunJMC1.Startup))]
namespace RunJMC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
