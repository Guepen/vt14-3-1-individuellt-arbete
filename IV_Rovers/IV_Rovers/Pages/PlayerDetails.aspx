﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PlayerDetails.aspx.cs" Inherits="IV_Rovers.Pages.PlayerDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="FormView1" runat="server"
        ItemType="IV_Rovers.Model.Player"
        SelectMethod="FormView1_GetItem"
        DeleteMethod="FormView1_DeleteItem"
        RenderOuterTable="false" 
        DefaultMode="ReadOnly"
        >
       <%-- mall för att visa spelare--%>
        <ItemTemplate>
            <div>
                <label>Firstname: </label>
                <%#: Item.FName %>
            </div>

            <div>
                <label>LastName: </label>
                <%#: Item.LName %>
            </div>

            <div>
                <label>Height(cm): </label>
                <%#: Item.Height %>
            </div>

            <div>
                <label>Weight(kg): </label>
                <%#: Item.Weight %>
            </div>

            <div>
                <label>Shirtnumber: </label>
                <%#: Item.ShirtNr %>
            </div>
            
           <%-- visar spelarens alla positioner--%>
            <asp:ListView ID="ListView1" runat="server"
                ItemType="IV_Rovers.Model.Position"
                SelectMethod="ListView1_GetData"
                OnItemDataBound="Player_ItemDataBound">
                <ItemTemplate>
                    <asp:MultiView ID="PositionMultiView" runat="server" ActiveViewIndex="0">
                        <asp:View runat="server">
                            <li>
                                <asp:Label ID="PositionLabel" runat="server"/>
                            </li>
                        </asp:View>
                    </asp:MultiView>

                </ItemTemplate>
            </asp:ListView>

            <div id="Menu">
               <%-- länkar för att ta komma till redigeringssidan, ta bort spelare och gå till listan med spelare--%>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit" NavigateUrl='<%# GetRouteUrl("Edit", new { id = Item.PlayerID }) %>' />
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="Ta Bort" CausesValidation="false" OnClientClick="return confirm('Är du säker på att du vill ta bort Spelaren?')" />
                <asp:HyperLink ID="HyperLink3" runat="server" Text="Go To List" NavigateUrl='<%# GetRouteUrl("PlayerList", null)%>' />
            </div>
        </ItemTemplate>

    </asp:FormView>


</asp:Content>
