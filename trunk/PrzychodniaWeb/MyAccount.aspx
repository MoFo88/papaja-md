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

        <br />
        <h2>Główne informacje:</h2>
        <p><asp:Label ID="lblPesel_" runat="server" Text="Pesel: "></asp:Label><asp:Label id="lblPesel" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblPhone_" runat="server" Text="Telefon: "></asp:Label><asp:Label id="lblPhone" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblEmail_" runat="server" Text="Email: "></asp:Label><asp:Label id="lblEmail" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblAdres_" runat="server" Text="Adres: "></asp:Label><asp:Label id="lblAdres" runat="server"></asp:Label></p>
        
        <div class="hours">
        <h2>Godziny przyjęć:</h2>

        <table>
            <tr>
                <th>Poniedziałek</th>
                <th>Wtorek</th>
                <th>środa</th>
                <th>Czwartek</th>
                <th>Piątek</th>
                <th>Sobota</th>
                <th>Niedziela</th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDay1" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDay2" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDay3" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDay4" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDay5" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDay6" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDay7" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        </div>

        <asp:Panel ID="panelShowEdidPassword" runat="server" CssClass="showPanel">
            <div class="imageArrow" ><asp:Image  ToolTip="Zmień hasło" runat="server" CssClass="imageArrow" id="arrow2" ImageUrl="~/images/arrowDown2.jpg"/><asp:Label runat="server" ID="Label1" Text="Zmień hasło"></asp:Label></div>
        </asp:Panel>
        
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" ImageControlID="arrow2" CollapsedImage="~/images/arrowDown2.jpg" ExpandedImage="~/images/arrowUp2.jpg" TargetControlID="panelEditPassword" Collapsed="true" CollapseControlID="panelShowEdidPassword"  ExpandControlID="panelShowEdidPassword">
        </asp:CollapsiblePanelExtender>
        
        <asp:Panel ID="panelEditPassword" runat="server" CssClass="collapsePanel">
            <div class="accountInfo">
            <fieldset>
                <legend>Zmień hasło</legend>
                <p>
                    <asp:Label ID="lblPassword_" runat="server">Hasło:</asp:Label>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblConfPassword_" runat="server">Potwierdz hasło:</asp:Label>
                    <asp:TextBox ID="tbConfPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                </p>
                <p class="submitButton">
                <asp:Button ID="btnChangePassword" runat="server" Text="Edytuj" 
                        onclick="btnChangePassword_Click"  />
                </p>
                <p>
                    <asp:Label ID="lblPasswordChangeMessage" runat="server" Text=""></asp:Label>
                </p>
                </fieldset>
            </div>
        </asp:Panel>


        <asp:Panel ID="panelShowEdit" runat="server" CssClass="showPanel" >
           <div class="imageArrow" ><asp:Image  ToolTip="Edytuj Dane" runat="server" CssClass="imageArrow" id="arrow" ImageUrl="~/images/arrowDown2.jpg"/><asp:Label runat="server" ID="lblEdit" Text="Edytuj dane"></asp:Label></div>
        </asp:Panel>
        
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtenderpanelEdit" runat="server" ImageControlID="arrow" CollapsedImage="~/images/arrowDown2.jpg" ExpandedImage="~/images/arrowUp2.jpg" TargetControlID="panelEdit" Collapsed="true" CollapseControlID="panelShowEdit"  ExpandControlID="panelShowEdit" SuppressPostBack="true">
        </asp:CollapsiblePanelExtender>
        <asp:Panel ID="panelEdit" runat="server" CssClass="collapsePanel">
          
        <div class="accountInfo">
            <fieldset>
                <legend>Edytuj dane</legend>
                <p>
                    <asp:Label ID="lblEditName_" runat="server">Imię:</asp:Label>
                    <asp:TextBox ID="tbEditName" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditSurname_" runat="server">Nazwisko:</asp:Label>
                    <asp:TextBox ID="tbEditSurname" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
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
                 <p>
                    <asp:Label ID="lblEditLogin_" runat="server">Login:</asp:Label>
                    <asp:TextBox ID="tbEditLogin" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditMessage" runat="server" Text=""></asp:Label>
                </p>
                
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="btnSubmitEdit" runat="server" Text="Edytuj" 
                    onclick="btnSubmitEdit_Click" />
            </p>
        </div>

        </asp:Panel>


        <asp:Panel ID="panelShowSpec" runat="server" CssClass="showPanel">
            <div class="imageArrow" ><asp:Image  ToolTip="Moja specjalizacja" runat="server" CssClass="imageArrow" id="arrow3" ImageUrl="~/images/arrowDown2.jpg"/><asp:Label runat="server" ID="Label2" Text="Zmień specjalizację"></asp:Label></div>
        </asp:Panel>
        
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" ImageControlID="arrow3" CollapsedImage="~/images/arrowDown2.jpg" ExpandedImage="~/images/arrowUp2.jpg" TargetControlID="panelEditSpec" Collapsed="true" CollapseControlID="panelShowSpec"  ExpandControlID="panelShowSpec">
        </asp:CollapsiblePanelExtender>

        <asp:Panel ID="panelEditSpec" CssClass="collapsePanel" runat="server">
        <%--<div class="cbCpec">
            <fieldset>
                <legend>Specjalizacje</legend> --%>
                <asp:Panel ID="panelEditSpec2" runat="server">
                </asp:Panel>
                <%--</fieldset>
        </div>--%>
        </asp:Panel>

        <asp:Panel ID="MyPatients" runat="server">
        </asp:Panel>

    </div>

</asp:Content>

