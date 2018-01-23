using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetMagic.Startup))]
namespace BudgetMagic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
