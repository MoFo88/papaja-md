<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" /><asp:Label
        ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
</asp:Content>

