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
    <div style="text-align:center;">
    <div style=" /*width: 400px;*/ border :2px solid, gray; padding: 20px 100px 0px 100px; margin: 0px 50px 20px 50px">
        <h3 class="style1" align="right">
        Ninejszy system jest kompletnym systemem obsługi
            przychodni lekarza rodzinnego.</h3>
        <p class="style1">
            Dalsze opcje systemu dostępne są po zalogowaniu.</p>
        <p class="style1">
            Życzymy miłego korzystania z Systemu.</p>
    </div>
        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/eskulap (1).jpg" Width="300" 
            style="text-align: center" />
    </div>
</asp:Content>
