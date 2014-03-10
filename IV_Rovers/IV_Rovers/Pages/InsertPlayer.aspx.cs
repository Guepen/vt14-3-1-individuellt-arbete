﻿using IV_Rovers.Model;
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
    }
}