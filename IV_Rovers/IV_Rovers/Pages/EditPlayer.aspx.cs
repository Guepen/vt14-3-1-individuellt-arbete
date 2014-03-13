using IV_Rovers.Model;
using System;
using System.Collections;
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
        private int PlayerID;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Player FormView1_GetItem([RouteData] int id)
        {
            try
            {
                PlayerID = id;
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
                // spelaren hittades inte
                ModelState.AddModelError(String.Empty, String.Format("Spelaren med spelarID {0} hittades inte", PlayerID));
                return;
            }

            //om player klarar valideringen
            if (TryUpdateModel(player))
            {
                //sparar spelarens nya uppgifter
                Service.SavePlayer(player);

                var checkBoxList = FormView1.FindControl("CheckBoxList") as CheckBoxList;

                //hämtar ut en lista på spelarens positioner
                //som används för att kolla om spelaren redan har vald position
                var playrPos = Service.GetPosition(PlayerID).ToList();
               
                //loopar igenom alla kryssrutor 
                for (int i = 0; i < checkBoxList.Items.Count; i++)
                {
                    var position = new Position();
                    position.PlTypeID = int.Parse(checkBoxList.Items[i].Value);
                    position.PlayerID = player.PlayerID;

                    if (!checkBoxList.Items[i].Selected)
                    {
                        for (int x = 0; x < playrPos.Count; x++)
                        {
                            if (playrPos[x].PlTypeID == position.PlTypeID)
                            {
                                Service.DeletePosition(position);
                            }
                        }
                    }

                    else
                    {
                            Service.SavePosition(position);
                    }
                }

                Page.SetTempData("successMessage", "The player was updated!");
                Response.RedirectToRoute("Details", new { id = PlayerID });
                Context.ApplicationInstance.CompleteRequest();
                }
                }
            
        public IEnumerable<PlayerType> PlayerFormView_GetItem()
        {
            return Service.GetPlayerTypes();
        }

        protected void UpdatePosition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var checkBoxList = FormView1.FindControl("CheckBoxList") as CheckBoxList;

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

        protected void CheckBoxList_DataBound(object sender, EventArgs e)
        {
            var checkBoxes = sender as CheckBoxList;
            var playrPos = Service.GetPosition(PlayerID).ToList();

            foreach (var checkbox in checkBoxes.Items.Cast<ListItem>())
            {
                for (int x = 0; x < playrPos.Count; x++)
                {
                    if (playrPos[x].PlTypeID.ToString() == checkbox.Value)
                    {
                        checkbox.Selected = true;
                    }
                }
            }
        }
    }
}
