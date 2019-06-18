using System;
using System.Threading.Tasks;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LYLStudio.App.Web.Startup))]

namespace LYLStudio.App.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 如需如何設定應用程式的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=316888
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
