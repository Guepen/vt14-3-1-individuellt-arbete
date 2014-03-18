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

        //objektet skapas först när det behövs
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       //hämtar spelare per ID
        public Player FormView1_GetItem([RouteData] int id)
        {
            return Service.GetPlayerByID(id);
        }

        public void FormView1_DeleteItem([RouteData] int id)
        {
            try
            {
                Service.DeletePlayerID(id);
                Page.SetTempData("successMessage", "The player was deleted!");
                Response.Redirect("~/Pages/PlayerList.aspx");
               
                //Bättre lösning men fungerar ej!
               // Response.RedirectToRoute("PlayerList", null);
                //Context.ApplicationInstance.CompleteRequest();
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade vid försök till att radera kontakt");
            }
        }

        //Hämtar ut alla spelarens positionsID
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
   
                //alla spelaren positioner skrivs ut i en label
                label.Text = Service.GetPlayerTypeByID(position.PlTypeID).PlType;
            
            }
	
            }
        }
    }
