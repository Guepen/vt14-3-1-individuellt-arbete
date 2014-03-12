using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV_Rovers.Model;

namespace IV_Rovers.Pages
{
    public partial class PlayerList : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SuccessLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessLiteral.Visible = !String.IsNullOrWhiteSpace(SuccessLiteral.Text);

            var table = PlayerListView.FindControl("Table") as Table; 
        }

       public IEnumerable<Player>PlayerListView_GetData()
        {
            return Service.GetPlayers();
        }

        }
    }
