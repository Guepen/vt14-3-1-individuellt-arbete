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
            //SuccessLiteral.text tilldelas en sträng som hämtas ut från min extensionmethod GetTempData i klassen PageExtensions
            //som ligger i mappen App_Infrastructure
            SuccessLiteral.Text = Page.GetTempData("successMessage") as string;
            
            //Min kontroll panel i masterpagen blir synlig om det finns ett meddelande att visa.
            SuccessPanel.Visible = !String.IsNullOrWhiteSpace(SuccessLiteral.Text);
            
            //Hämtar ut vilket stylesheet som skall användas
            var layout = Page.GetLayOut("Layout") as string;
            
            //Om det finns en länk att hämta i min extension
            //Annars gäller länken i min masterpage
            if (layout != null)
            {
                Literal1.Text = layout;
            }
        }

        //om användaren trycker på knappen "Crazy Layout"
        protected void Button1_Click(object sender, EventArgs e)
        {
            //strängen style tilldelas länk till vald layout
            string style = "<LINK href=\'/1dv406/th222fa/Content/Crazy.css\' type=\"text/css\" rel=\"stylesheet\">";
            string audioFile;

            //stylesheetlänken i min masterpage sätts till vald layout
            Literal1.Text = style;
            Page.SetTempData("Layout", Literal1.Text);
            
            //sökevägen till min ljudfil
            audioFile = System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\Crazy.wav");
            SoundPlayer sound = new SoundPlayer(audioFile);

            //Startar låten
            sound.PlayLooping();



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //strängen style tilldelas länk till vald layout
            string style = "<LINK href=\"/1dv406/th222fa/Content/Style.css\" type=\"text/css\" rel=\"stylesheet\">";

            //stylesheetlänken i min masterpage sätts till vald layout
            Literal1.Text = style;
            Page.SetTempData("Layout", Literal1.Text);
            //SoundPlayer sound = new SoundPlayer(@"Content\Crazy.wav");
            string audioFile;
            audioFile = System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\Crazy.wav");
            SoundPlayer sound = new SoundPlayer(audioFile);
            sound.Stop();
        }
    }
}