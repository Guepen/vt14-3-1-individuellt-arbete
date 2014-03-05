<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PlayerList.aspx.cs" Inherits="IV_Rovers.Pages.PlayerList" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="PlayerListView" runat="server"
        ItemType="IV_Rovers.Model.Player"
        SelectMethod="PlayerListView_GetData"
        DataKeyNames="PlayerID"
        >
        <LayoutTemplate>
                    <table class="Table">
                        <tr>
                            <th>
                                Firstname
                            </th>
                            <th>
                                Lastname
                            </th>
                            <th>
                                Height
                            </th>
                            <th>
                                Weight
                            </th>
                            <th>
                                Shirtnumber
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
            </tr>
        </ItemTemplate>

    </asp:ListView>
</asp:Content>


