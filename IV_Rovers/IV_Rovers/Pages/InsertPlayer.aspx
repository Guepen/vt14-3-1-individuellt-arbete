<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="InsertPlayer.aspx.cs" Inherits="IV_Rovers.Pages.InsertPlayer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Insert" />
    <asp:FormView ID="PlayerFormView" runat="server"
        ItemType="IV_Rovers.Model.Player"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="PlayerFormView_InsertItem">
        
        <InsertItemTemplate>
            <h2>New Player</h2>
            <div>
                <label>Firstname</label>
            </div>
            <div>
                <asp:TextBox ID="FName" runat="server" Text='<%# BindItem.FName %>' MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Förnamn måste anges"
                    ControlToValidate="FName" ValidationGroup="Insert" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label>Lastname</label>
            </div>
            <div>
                <asp:TextBox ID="LName" runat="server" Text='<%# BindItem.LName %>' MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="EfterNamn måste anges"
                    ControlToValidate="LName" ValidationGroup="Insert" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label>Height</label>
            </div>
            <div>
                <asp:TextBox ID="Height" runat="server" Text='<%# BindItem.Height %>' MaxLength="3" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Längd måste anges"
                    ControlToValidate="Height" ValidationGroup="Insert" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label>Weight</label>
            </div>
            <div>
                <asp:TextBox ID="Weight" runat="server" Text='<%# BindItem.Weight %>' MaxLength="3" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Vikt måste anges"
                    ControlToValidate="ShirtNr" ValidationGroup="Insert" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label>Shirtnumber</label>
            </div>
            <div>
                <asp:TextBox ID="ShirtNr" runat="server" Text='<%# BindItem.ShirtNr %>' MaxLength="3" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Tröjnummmer måste anges"
                    ControlToValidate="ShirtNr" ValidationGroup="Insert" Display="None"></asp:RequiredFieldValidator>
            </div>
            <h2>Position</h2>
              <asp:CheckBoxList ID="CheckBoxList" runat="server"  ItemType="IV_Rovers.Model.PlayerType" DataValueField="PlTypeID" DataTextField="PlType" SelectMethod="PlayerFormView_GetItem"  RepeatColumns="5" RepeatLayout="Table" />
              <asp:CustomValidator ID="InsertPosition" runat="server" ValidationGroup="Insert" OnServerValidate="InsertPosition_ServerValidate" ErrorMessage="You must Select atleast one position!" ></asp:CustomValidator>
            <div>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" ValidationGroup="Insert" />
                <asp:HyperLink ID="HyperLink3" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("PlayerList", null)%>' />
            </div>
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
