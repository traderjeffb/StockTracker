using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockMarketTracker.Startup))]
namespace StockMarketTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
