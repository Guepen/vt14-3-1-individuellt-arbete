using System;
using System.Web.Routing;

namespace IV_Rovers
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.Routes(RouteTable.Routes);
        }

    }
}