using Microsoft.Owin;
using Owin;
using ProtechTeste.Repository.Context;

[assembly: OwinStartupAttribute(typeof(ProtechTeste.Web.Startup))]
namespace ProtechTeste.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);            
        }
    }
}
