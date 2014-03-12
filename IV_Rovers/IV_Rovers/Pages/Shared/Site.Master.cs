using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace IV_Rovers.Pages.Shared
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var layout = Page.GetLayOut("Layout") as string;
            if (layout != null)
            {
                Literal1.Text = layout;
            }
            else 
            {
                const string style = "<LINK href=\"../../Content/Style.css\" type=\"text/css\" rel=\"stylesheet\">";
                Literal1.Text = style;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            const string style = "<LINK href=\'../../Content/Crazy.css\' type=\"text/css\" rel=\"stylesheet\">";
            Literal1.Text = style;
            Page.SetTempData("Layout", Literal1.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            const string style = "<LINK href=\"../../Content/Style.css\" type=\"text/css\" rel=\"stylesheet\">";
            Literal1.Text = style;
            Page.SetTempData("Layout", Literal1.Text);
        }
    }
}