<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PlayerDetails.aspx.cs" Inherits="IV_Rovers.Pages.PlayerDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="FormView1" runat="server"
        ItemType="IV_Rovers.Model.Player"
        SelectMethod="FormView1_GetItem"
        DeleteMethod="FormView1_DeleteItem"
        RenderOuterTable="false"
        >
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
                <label>Height: </label>
                <%#: Item.Height %>
            </div>

            <div>
                <label>Weight: </label>
                <%#: Item.Weight %>
            </div>

            <div>
                <label>Shirtnumber: </label>
                <%#: Item.ShirtNr %>
            </div>
              <div>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit" NavigateUrl='<%# GetRouteUrl("Edit", new { id = Item.PlayerID }) %>' />
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="Ta Bort" CausesValidation="false" OnClientClick="return confirm('Är du säker på att du vill ta bort Spelaren?')" />
                <asp:HyperLink ID="HyperLink3" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("PlayerList", null)%>' />
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
