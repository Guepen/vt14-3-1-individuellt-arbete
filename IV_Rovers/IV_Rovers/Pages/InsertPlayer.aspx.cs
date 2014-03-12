using IV_Rovers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script;

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
            var FirstNameBox = PlayerFormView.FindControl("FName") as TextBox;
            FirstNameBox.Focus();
        }

        public void PlayerFormView_InsertItem(Player player)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Service.SavePlayer(player);
                    var checkBoxList = PlayerFormView.FindControl("CheckBoxList") as CheckBoxList;

                    for (int i = 0; i < checkBoxList.Items.Count; i++)
                    {
                        if (checkBoxList.Items[i].Selected)
                        {
                            var position = new Position();
                            position.PlTypeID = int.Parse(checkBoxList.Items[i].Value);
                            position.PlayerID = player.PlayerID;
                            Service.SavePosition(position);
                        }
                    }

                    Page.SetTempData("SuccessMessage", "The player was inserted!");
                    Response.RedirectToRoute("Details", new { id = player.PlayerID });
                    Context.ApplicationInstance.CompleteRequest();

                }

                catch
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när spelare skulle läggas till");
                }

            }
        }


        public IEnumerable<PlayerType> PlayerFormView_GetItem()
        {
            return Service.GetPlayerTypes();
        }

        protected void InsertPosition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var checkBoxList = PlayerFormView.FindControl("CheckBoxList") as CheckBoxList;

            var checkboxHasValue = checkBoxList.SelectedItem;

            if (checkboxHasValue != null)
            {
                args.IsValid = true;
            }

            else
            {
                args.IsValid = false;
            }

        }


    }
}