<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="IV_Rovers.Pages.Shared.Error" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ett serverfel inträffade!</h1>
    <p>Var vänlig och tryck på länken nedan för att komma tillbaka till spelarlistan</p>
    <asp:HyperLink ID="HyperLink1" Text="Back To List"  NavigateUrl="<%$ RouteUrl:routename=PlayerList %>" runat="server"/>
</asp:Content>

