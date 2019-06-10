using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LYLStudio.App.Middle.Startup))]

namespace LYLStudio.App.Middle
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 如需如何設定應用程式的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=316888

            //自訂全域功能註冊
            GlobalConfig.Register();
        }
    }
}
