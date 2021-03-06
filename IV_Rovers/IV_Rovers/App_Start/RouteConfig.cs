﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace IV_Rovers
{
    public class RouteConfig
    {
        public static void Routes(RouteCollection routes)
        {
            routes.MapPageRoute("Default", "", "~/Pages/PlayerList.aspx");
            routes.MapPageRoute("PlayerList", "Playerlist", "~/Pages/PlayerList.aspx");
            routes.MapPageRoute("InsertPlayer", "Player/New", "~/Pages/InsertPlayer.aspx");
            routes.MapPageRoute("Details", "Player/{id}", "~/Pages/PlayerDetails.aspx");
            routes.MapPageRoute("Edit", "Player/Edit/{id}", "~/Pages/EditPlayer.aspx");
            routes.MapPageRoute("Delete", "Player/Delete/{id}", "~/Pages/DeletePlayer.aspx");
            routes.MapPageRoute("Error", "Error2", "~/Pages/Error.aspx");
        }
    }
}