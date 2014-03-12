using System;
using System.Web.Routing;
using System.Web.UI;

namespace IV_Rovers
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.Routes(RouteTable.Routes);
            
           var jQuery = new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-2.1.0.min.js",
                DebugPath = "~/Scripts/jquery-2.1.0.js",
                CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.0.3.min.js",
                CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.0.3.js"
            };

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery);
        }

    }
}