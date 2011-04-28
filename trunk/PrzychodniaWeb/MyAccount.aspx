<%@  Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount"    %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath ="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class = "myData">
        
        <asp:Image id="myImage" CssClass="myImage" ImageUrl ="images/no_user.png" runat="server" />
        <h1><asp:Label ID="lblName" runat="server" Text=""></asp:Label></h1>  
        <asp:Panel ID="panelSpec" CssClass="panelMySpec" runat="server"></asp:Panel>

        <ul>
            <li><asp:Label ID="lblPesel_" runat="server" Text="Pesel: "></asp:Label><asp:Label id="lblPesel" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblPhone_" runat="server" Text="Telefon: "></asp:Label><asp:Label id="lblPhone" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblEmail_" runat="server" Text="Email: "></asp:Label><asp:Label id="lblEmail" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblAdres_" runat="server" Text="Adres: "></asp:Label><asp:Label id="lblAdres" runat="server"></asp:Label></li>
        </ul>

        <br />
        <asp:Panel ID="panelShgowEdit" runat="server">
            <asp:Label ID="lblEdit" runat="server" Text="Edytuj"></asp:Label>
        </asp:Panel>
        
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtenderpanelEdit" runat="server" TargetControlID="panelEdit" Collapsed="true" CollapseControlID="panelShgowEdit" ExpandControlID="panelShgowEdit" SuppressPostBack="true">
        </asp:CollapsiblePanelExtender>
        <asp:Panel ID="panelEdit" runat="server" CssClass="collapsePanel">
            
        <div class="accountInfo">
            <fieldset>
                <legend>Edytuj dane</legend>
                <p>
                    <asp:Label ID="lblEditPesel_" runat="server">Pesel:</asp:Label>
                    <asp:TextBox ID="tbEditPesel" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditPhone_" runat="server">Telefon:</asp:Label>
                    <asp:TextBox ID="tbEditPhone" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditEmail_" runat="server">Email:</asp:Label>
                    <asp:TextBox ID="tbEditEmail" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditStreet_" runat="server">Ulica:</asp:Label>
                    <asp:TextBox ID="tbEditStreet" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditStreetNr_" runat="server">Numer domu::</asp:Label>
                    <asp:TextBox ID="tbEditStreetNr" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditPostalCode_" runat="server">Kod pocztowy:</asp:Label>
                    <asp:TextBox ID="tbEditPostalCode" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditCity_" runat="server">Miasto:</asp:Label>
                    <asp:TextBox ID="tbEditCity" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="btnSubmitEdit" runat="server" Text="Edytuj" />
            </p>
        </div>

        </asp:Panel>

    </div>

</asp:Content>

