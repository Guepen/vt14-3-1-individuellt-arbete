using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace IV_Rovers.Pages.Shared
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SuccessLiteral.Text = Page.GetTempData("successMessage") as string;
            SuccessPanel.Visible = !String.IsNullOrWhiteSpace(SuccessLiteral.Text);
            var layout = Page.GetLayOut("Layout") as string;
            if (layout != null)
            {
                Literal1.Text = layout;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            const string style = "<LINK href=\'../../Content/Crazy.css\' type=\"text/css\" rel=\"stylesheet\">";
            string audioFile;
            Literal1.Text = style;
            Page.SetTempData("Layout", Literal1.Text);
            audioFile = System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content/Crazy.wav");
            SoundPlayer sound = new SoundPlayer(audioFile);
            sound.PlayLooping();



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            const string style = "<LINK href=\"../../Content/Style.css\" type=\"text/css\" rel=\"stylesheet\">";
            Literal1.Text = style;
            Page.SetTempData("Layout", Literal1.Text);
            SoundPlayer sound = new SoundPlayer(@"Content/Crazy.wav");
            sound.Stop();
        }
    }
}