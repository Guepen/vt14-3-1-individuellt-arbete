<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PlayerList.aspx.cs" Inherits="IV_Rovers.Pages.PlayerList" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="NewPlayer">
        <asp:HyperLink runat="server" Text="New Player" NavigateUrl="<%$ RouteUrl:routename=InsertPlayer %>" />
      
    </div>
    <asp:ListView ID="PlayerListView" runat="server"
        ItemType="IV_Rovers.Model.Player"
        SelectMethod="PlayerListView_GetData"
        UpdateMethod="PlayerListView_UpdateItem"
        DeleteMethod="PlayerListView_DeleteItem"
        DataKeyNames="PlayerID">
        <LayoutTemplate>
            <table id="Table">
                <tr>
                    <th>Firstname
                    </th>
                    <th>Lastname
                    </th>
                    <th>Height
                    </th>
                    <th>Weight
                    </th>
                    <th>Shirtnumber
                    </th>
                    <th>
                        Deatils
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#: Item.FName %>
                </td>
                <td>
                    <%#: Item.LName %>
                </td>
                <td>
                    <%#: Item.Height %>
                </td>
                <td>
                    <%#: Item.Weight %>
                </td>
                <td>
                    <%#: Item.ShirtNr %>
                </td>
      
                <td>
                    <asp:HyperLink  Text="More Information" runat="server" NavigateUrl='<%# GetRouteUrl("Details", new { id = Item.PlayerID})%>'/>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då uppgifter saknas i databasen. --%>
            <table>
                <tr>
                    <td>Spelaruppgifter saknas.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>


