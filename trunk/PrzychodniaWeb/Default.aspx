<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath ="~/Site.master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="defaultDiv">
    <div class="mainText" >Systemem obsługi przychodni<br />lekarza rodzinnego &quot; Papaja &quot; </div>

    </div>
    <div style="text-align:center; padding-top: 25px">
        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/eskulap (1).jpg" Width="300" 
            style="text-align: center" />
    </div>
</asp:Content>
