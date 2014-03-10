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
                GetRouteUrl("PlayerList");
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade vid försök till att radera kontakt");
            }
        }
    }
}