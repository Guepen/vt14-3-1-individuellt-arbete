using IV_Rovers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IV_Rovers.Pages
{
    public partial class InsertPlayer : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void PlayerFormView_InsertItem(Player player)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SavePlayer(player);
                }

                catch
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när spelare skulle läggas till");
                }

            }
        }
    }
}