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
            <div class="imageArrowContainer" ><asp:Image  ToolTip="Zmień hasło" runat="server" CssClass="imageArrow" id="arrow2" ImageUrl="~/images/arrowDown2.png"/><asp:Label runat="server" ID="Label1" Text="Zmień hasło"></asp:Label></div>
        </asp:Panel>
        
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" ImageControlID="arrow2" CollapsedImage="~/images/arrowDown2.png" ExpandedImage="~/images/arrowUp2.png" TargetControlID="panelEditPassword" Collapsed="true" CollapseControlID="panelShowEdidPassword"  ExpandControlID="panelShowEdidPassword">
        </asp:CollapsiblePanelExtender>
        
        <asp:Panel ID="panelEditPassword" runat="server" CssClass="collapsePanel">
            <div class="accountInfo">

            <asp:ValidationSummary 
                                ID="editPasswordValidationSummary" 
                                runat="server" 
                                CssClass="failureNotification" 
                                ValidationGroup="editPasswordValidationGroup"/>

            <fieldset>
                <legend>Zmień hasło</legend>
                <p>
                    <asp:Label ID="lblPassword_" runat="server">Hasło:</asp:Label>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="passwordRequired" runat="server" ControlToValidate="tbPassword" 
                             CssClass="failureNotification" ErrorMessage="Hasło jest wymagane." ToolTip="Hasło jest wymagane." 
                             ValidationGroup="editPasswordValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblConfPassword_" runat="server">Potwierdz hasło:</asp:Label>
                    <asp:TextBox ID="tbConfPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="confirmPasswordRequiredFieldValidator" runat="server" ControlToValidate="tbConfPassword" 
                             CssClass="failureNotification" ErrorMessage="Potwierdzenie Hasła jest wymagane." ToolTip="Potwierdzeie hasła jest wymagane." 
                             ValidationGroup="editPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="passwordCompareValidator" runat="server" 
                            ErrorMessage="Hasła nie są identyczne." 
                            ValidationGroup="editPasswordValidationGroup" 
                            ControlToValidate="tbPassword"
                            ControlToCompare="tbConfPassword"
                            CssClass="failureNotification"
                            ToolTip="Hasła nie są identyczne"
                            >*</asp:CompareValidator>
                </p>

                <p>
                    <asp:Label ID="lblPasswordChangeMessage" runat="server" Text=""></asp:Label>
                </p>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnChangePassword" runat="server" Text="Edytuj" 
                        onclick="btnChangePassword_Click" ValidationGroup = "editPasswordValidationGroup"  />
                </p>
            </div>
        </asp:Panel>


        <asp:Panel ID="panelShowEdit" runat="server" CssClass="showPanel" >
           <div class="imageArrowContainer" ><asp:Image  ToolTip="Edytuj Dane" runat="server" CssClass="imageArrow" id="arrow" ImageUrl="~/images/arrowDown2.png"/><asp:Label runat="server" ID="lblEdit" Text="Edytuj dane"></asp:Label></div>
        </asp:Panel>
        
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtenderpanelEdit" runat="server" ImageControlID="arrow" CollapsedImage="~/images/arrowDown2.png" ExpandedImage="~/images/arrowUp2.png" TargetControlID="panelEdit" Collapsed="true" CollapseControlID="panelShowEdit"  ExpandControlID="panelShowEdit" SuppressPostBack="true">
        </asp:CollapsiblePanelExtender>
        <asp:Panel ID="panelEdit" runat="server" CssClass="collapsePanel">
          
        <div class="accountInfo">

        <asp:ValidationSummary 
                            ID="editDataValidationSummary" 
                            runat="server" 
                            CssClass="failureNotification" 
                            ValidationGroup="editDataValidationGroup"/>

            <fieldset>
                <legend>Edytuj dane</legend>
                <p>
                    <asp:Label ID="lblEditName_" runat="server">Imię:</asp:Label>
                    <asp:TextBox ID="tbEditName" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                                        ID="tbEditNameRequiredFieldValidator" 
                                        runat="server" 
                                        ControlToValidate="tbEditName" 
                                        CssClass="failureNotification" 
                                        ErrorMessage="Imię jest wymagane." 
                                        ToolTip="Imię jest wymagane." 
                                        ValidationGroup="editDataValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblEditSurname_" runat="server">Nazwisko:</asp:Label>
                    <asp:TextBox ID="tbEditSurname" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                                        ID="tbEditSurnameRequiredFieldValidator" 
                                        runat="server" 
                                        ControlToValidate="tbEditSurname" 
                                        CssClass="failureNotification" 
                                        ErrorMessage="Nazwisko jest wymagane." 
                                        ToolTip="Nazwisko jest wymagane." 
                                        ValidationGroup="editDataValidationGroup">*</asp:RequiredFieldValidator>
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
                    <asp:RegularExpressionValidator 
                                        ID="tbEditEmailRegularExpressionValidator" 
                                        runat="server"
                                        ControlToValidate="tbEditEmail" 
                                        ValidationGroup="editDataValidationGroup"
                                        ToolTip="Błędny adres email"
                                        CssClass="failureNotification"
                                        ErrorMessage="Błędny adres email." 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </p>
                <p>
                    <asp:Label ID="lblEditStreet_" runat="server">Ulica:</asp:Label>
                    <asp:TextBox ID="tbEditStreet" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditStreetNr_" runat="server">Numer domu:</asp:Label>
                    <asp:TextBox ID="tbEditStreetNr" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblEditPostalCode_" runat="server">Kod pocztowy:</asp:Label>
                    <asp:TextBox ID="tbEditPostalCode" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RegularExpressionValidator 
                                        ID="tbEditPostalCodeRegularExpressionValidator" 
                                        runat="server" 
                                        ToolTip="Błedny kod pocztowy"
                                        ControlToValidate="tbEditPostalCode" 
                                        CssClass="failureNotification"
                                        ValidationGroup="editDataValidationGroup"
                                        ErrorMessage="Błedny kod pocztowy." 
                                        ValidationExpression="\d{2}-\d{3}">*</asp:RegularExpressionValidator>
                </p>
                <p>
                    <asp:Label ID="lblEditCity_" runat="server">Miasto:</asp:Label>
                    <asp:TextBox ID="tbEditCity" runat="server" CssClass="textEntry"></asp:TextBox>
                </p>
                 <p>
                    <asp:Label ID="lblEditLogin_" runat="server">Login:</asp:Label>
                    <asp:TextBox ID="tbEditLogin" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                                        ID="tbEditLoginRequiredFieldValidator" 
                                        runat="server" 
                                        ControlToValidate="tbEditLogin" 
                                        CssClass="failureNotification" 
                                        ErrorMessage="Login jest wymagany." 
                                        ToolTip="Login jest wymagany." 
                                        ValidationGroup="editDataValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblEditMessage" runat="server" Text=""></asp:Label>
                </p>
                
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="btnSubmitEdit" runat="server" Text="Edytuj" onclick="btnSubmitEdit_Click" ValidationGroup="editDataValidationGroup" />
            </p>
        </div>

        </asp:Panel>


        <asp:Panel ID="panelShowSpec" runat="server" CssClass="showPanel">
            <div class="imageArrowContainer" ><asp:Image  ToolTip="Moja specjalizacja" runat="server" CssClass="imageArrow" id="arrow3" ImageUrl="~/images/arrowDown2.png"/><asp:Label runat="server" ID="Label2" Text="Zmień specjalizację"></asp:Label></div>
        </asp:Panel>
        
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" ImageControlID="arrow3" CollapsedImage="~/images/arrowDown2.png" ExpandedImage="~/images/arrowUp2.png" TargetControlID="panelEditSpec" Collapsed="true" CollapseControlID="panelShowSpec"  ExpandControlID="panelShowSpec">
        </asp:CollapsiblePanelExtender>

        <asp:Panel ID="panelEditSpec" CssClass="collapsePanel" runat="server" Width="420px">
        <div class="cbCpec">
            <fieldset>
                <legend>Specjalizacje</legend>
                <asp:Panel ID="panelSpecializations" runat="server">
                <asp:Panel ID="panel1" runat="server">
                <asp:CheckBoxList 
                            ID="cblSpecializations" 
                            runat="server" 
                            DataTextField="nazwa" 
                            DataValueField="id" 
                            RepeatColumns="3" 
                            RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </asp:Panel>

            </asp:Panel>
                <p>
                    <asp:Label ID="lblSpecMessage" runat="server" Text=""></asp:Label>
                </p>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnEditSpec" runat="server" Text="Edytuj" 
                        onclick="btnEditSpec_Click" />
            </p>
        </div>
        </asp:Panel>


        <%--Linki--%>

        <asp:DynamicHyperLink ID="dhlAddNewDoctor" runat="server" NavigateUrl="~/MyPatients.aspx" >
                
                <div class="imageArrowContainer">
                <asp:Image ToolTip="Lista zaoptowanych pacjentów"  ID="Image1" runat="server" ImageUrl = "~/images/arrowRight.png" CssClass="imageArrow" />
                <asp:Label ID="lblAddNewDoctor" ToolTip="Lista zaoptowanych pacjentów"  runat="server" Text="Lista pacjentów"></asp:Label>
                </div>

        </asp:DynamicHyperLink>


    </div>

</asp:Content>

