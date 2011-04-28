<%@  Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount"    %>
<%@ MasterType VirtualPath ="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class = "myData">
        
        <asp:Image id="myImage" CssClass="myImage" ImageUrl ="images/no_user.png" runat="server" />
        <h1><asp:Label ID="lblName" runat="server" Text=""></asp:Label></h1>  
        <asp:Panel ID="panelSpec" CssClass="panelMySpec" runat="server"></asp:Panel>
    </div>

</asp:Content>

