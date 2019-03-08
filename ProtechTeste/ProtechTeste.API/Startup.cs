using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using ProtechTeste.Repository.Context;

[assembly: OwinStartup(typeof(ProtechTeste.API.Startup))]

namespace ProtechTeste.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
