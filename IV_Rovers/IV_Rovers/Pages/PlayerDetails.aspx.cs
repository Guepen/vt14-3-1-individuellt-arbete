using IV_Rovers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IV_Rovers.Pages
{
    public partial class PlayerDetails : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Player FormView1_GetItem([RouteData] int id)
        {
            return Service.GetPlayerByID(id);
        }

        public void FormView1_DeleteItem([RouteData] int id)
        {
            try
            {
                Service.DeletePlayer(id);
                Response.Redirect("~/Pages/PlayerList.aspx");
                //Bättre lösning men fungerar ej!
                //Response.RedirectToRoute("PlayerList");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade vid försök till att radera kontakt");
            }
        }

        public IEnumerable<Position> ListView1_GetData([RouteData] int id)
        {
            return Service.GetPosition(id);
        }

        protected void Player_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var label = e.Item.FindControl("PositionLabel") as Label;
            if (label != null)
            {
                // Typomvandlar e.Item.DataItem så att primärnyckelns värde kan hämtas och...
                var position = (Position)e.Item.DataItem;

                //var playerType = Service.GetPlayerTypeByID(position.PlTypeID).PlType;
                
                label.Text = Service.GetPlayerTypeByID(position.PlTypeID).PlType; 
                //position.PlTypeID; 
                // ...som sedan kan användas för att hämta ett ("cachat") kontakttypobjekt...

                // ...så att en beskrivning av kontaktypen kan presenteras; ex: Arbete: 012-345 67 89
                //label.Text = String.Format(label.Text);      
            }
        }
    }
}