using System;
using System.Configuration;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace LegacyWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
                .AddJsonSessionSerializer(options =>
                {
                    options.RegisterKey<string>("Mumin_ID");
                    options.RegisterKey<string>("MachineName");
                    options.RegisterKey<DateTime>("SessionStartTime");
                })
                .AddRemoteAppServer(options =>
                {
                    options.ApiKey = ConfigurationManager.AppSettings["RemoteAppServerApiKey"];
                })
                .AddSessionServer();

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session["MachineName"] = Environment.MachineName;
            HttpContext.Current.Session["SessionStartTime"] = DateTime.Now;
        }
    }
}