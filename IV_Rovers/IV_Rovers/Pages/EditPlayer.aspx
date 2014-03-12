<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditPlayer.aspx.cs" Inherits="IV_Rovers.Pages.Edit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Update" runat="server" ShowModelStateErrors="false" />
    <asp:Panel runat="server">
        <asp:Literal ID="PositionExists" Visible="false" runat="server"></asp:Literal></asp:Panel>
    <asp:FormView ID="FormView1" runat="server"
        SelectMethod="FormView1_GetItem"
        ItemType="IV_Rovers.Model.Player"
        UpdateMethod="FormView1_UpdateItem"
        DataKeyNames="PlayerID"
        RenderOuterTable="false"
        DefaultMode="Edit"
        >
        <EditItemTemplate>
             <div>
                <label>Firstname</label>
            </div>
            <div>
                <asp:TextBox ID="FName" runat="server" Text='<%# BindItem.FName %>' MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Förnamn måste anges"
                    ControlToValidate="FName" ValidationGroup="Update" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label>Lastname</label>
            </div>
            <div>
                <asp:TextBox ID="LName" runat="server" Text='<%# BindItem.LName %>' MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="EfterNamn måste anges"
                    ControlToValidate="LName" ValidationGroup="Update" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label>Height</label>
            </div>
            <div>
                <asp:TextBox ID="Height" runat="server" Text='<%# BindItem.Height %>' MaxLength="3" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Längd måste anges"
                    ControlToValidate="Height" ValidationGroup="Update" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label>Weight</label>
            </div>
            <div>
                <asp:TextBox ID="Weight" runat="server" Text='<%# BindItem.Weight %>' MaxLength="3" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Vikt måste anges"
                    ControlToValidate="Weight" ValidationGroup="Update" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label>Shirtnumber</label>
            </div>
            <div>
                <asp:TextBox ID="ShirtNr" runat="server" Text='<%# BindItem.ShirtNr %>' MaxLength="3" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Tröjnummmer måste anges"
                    ControlToValidate="ShirtNr" ValidationGroup="Update" Display="None"></asp:RequiredFieldValidator>
            </div>

            <asp:CheckBoxList ID="CheckBoxList" runat="server" ItemType="IV_Rovers.Model.PlayerType" DataValueField="PlTypeID" DataTextField="PlType" SelectMethod="PlayerFormView_GetItem" OnDataBound="CheckBoxList_DataBound"  ></asp:CheckBoxList>
            <asp:CustomValidator ID="UpdatePosition" runat="server" ValidationGroup="Update" OnServerValidate="UpdatePosition_ServerValidate" ErrorMessage="You must Select atleast one position!" Display="None"></asp:CustomValidator>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Update"/>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Details", new { id = Item.PlayerID }) %>' />
            </div>
        </EditItemTemplate>

    </asp:FormView>
</asp:Content>
