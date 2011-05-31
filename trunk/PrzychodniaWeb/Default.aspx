<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath ="~/Site.master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="defaultDiv">
    <asp:Image CssClass="mainImage" id="Image1" Width="200" ImageUrl ="images/e1.jpg" runat="server" />
    <div class="mainText" > przychodnia lekarza rodzinnego &quot; PAPAJA &quot; </div>
    <asp:Image id="myImage" Width="200" CssClass="myImage" BorderStyle="None" ImageUrl ="images/e2.jpg" runat="server" />

    </div>
        
</asp:Content>
