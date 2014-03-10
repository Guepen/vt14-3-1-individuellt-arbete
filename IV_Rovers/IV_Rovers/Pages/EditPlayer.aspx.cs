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
    public partial class Edit : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public object FormView1_GetItem([RouteData] int id)
        {
            try
            {
                return Service.GetPlayerByID(id);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då spelaren skulle redigeras.");
                return null;
            }
        }


        public void FormView1_UpdateItem(int PlayerID)
        {
            var player = Service.GetPlayerByID(PlayerID);

            if (player == null)
            {
                // The item wasn't found
                ModelState.AddModelError(String.Empty, String.Format("Spelaren med spelarID {0} hittades inte", PlayerID));
                return;
            }
            if (TryUpdateModel(player))
            {
                Service.SavePlayer(player);

            }
        }
    }
}