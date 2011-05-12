<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyAccountAdmin.aspx.cs" Inherits="MyAccountAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<%@ PreviousPageType VirtualPath="~/MyAccount.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class = "myData">    
        <asp:Image id="myImage" CssClass="myImage" ImageUrl ="images/no_user.png" runat="server" />
        <h1><asp:Label ID="lblAdmin" runat="server" Text="Administrator"></asp:Label></h1>  
        
        <br />
        <p><asp:Label ID="lblName_" runat="server" Text="Imię: "></asp:Label><asp:Label id="lblName" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblSurname_" runat="server" Text="Nazwisko: "></asp:Label><asp:Label id="lblSurname" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblPhone_" runat="server" Text="Telefon: "></asp:Label><asp:Label id="lblPhone" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblEmail_" runat="server" Text="Email: "></asp:Label><asp:Label id="lblEmail" runat="server"></asp:Label></p>
        
        <asp:Panel ID="panelShowEdidPassword" runat="server" CssClass="showPanel">
            <div class="imageArrowContainer" ><asp:Image  ToolTip="Zmień hasło" runat="server" CssClass="imageArrow" id="arrow2" ImageUrl="~/images/arrowDown2.jpg"/><asp:Label runat="server" ID="Label1" Text="Zmień hasło"></asp:Label></div>
        </asp:Panel>

        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" ImageControlID="arrow2" CollapsedImage="~/images/arrowDown2.jpg" ExpandedImage="~/images/arrowUp2.jpg" TargetControlID="panelEditPassword" Collapsed="true" CollapseControlID="panelShowEdidPassword"  ExpandControlID="panelShowEdidPassword">
        </asp:CollapsiblePanelExtender>
        
        <asp:Panel ID="panelEditPassword" runat="server" CssClass="collapsePanel">
            <div class="accountInfo">

            <asp:ValidationSummary ID="editPasswordValidationSummary" runat="server" CssClass="failureNotification" 
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

    </div>


    <asp:Panel ID="panelShowEdit" runat="server" CssClass="showPanel" >
           <div class="imageArrowContainer" ><asp:Image  ToolTip="Edytuj Dane" runat="server" CssClass="imageArrow" id="arrow" ImageUrl="~/images/arrowDown2.jpg"/><asp:Label runat="server" ID="lblEdit" Text="Edytuj dane"></asp:Label></div>
        </asp:Panel>
        
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtenderpanelEdit" runat="server" ImageControlID="arrow" CollapsedImage="~/images/arrowDown2.jpg" ExpandedImage="~/images/arrowUp2.jpg" TargetControlID="panelEdit" Collapsed="true" CollapseControlID="panelShowEdit"  ExpandControlID="panelShowEdit" SuppressPostBack="true">
        </asp:CollapsiblePanelExtender>
        <asp:Panel ID="panelEdit" runat="server" CssClass="collapsePanel">
          
            <div class="accountInfo">

            <asp:ValidationSummary ID="editDataValidationSummary" runat="server" CssClass="failureNotification" 
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

        <div id = "adminOptions" class="adminOptions">
            <asp:DynamicHyperLink ID="dhlAddNewDoctor" runat="server" NavigateUrl="~/AddNewDoctor.aspx" >
                
                <div class="imageArrowContainer">
                <asp:Image  ID="Image1" runat="server" ImageUrl = "~/images/arrowRight.jpg" CssClass="imageArrow" />
                <asp:Label ID="lblAddNewDoctor"  runat="server" Text="Dodaj lekarza"></asp:Label>
                </div>

            </asp:DynamicHyperLink>

            <asp:DynamicHyperLink ID="dhlAddNewPatient" runat="server" NavigateUrl="~/AddNewPatient.aspx" >
                
                <div class="imageArrowContainer">
                <asp:Image  ID="Image2" runat="server" ImageUrl = "~/images/arrowRight.jpg" CssClass="imageArrow" />
                <asp:Label ID="lblAddNewPatient"  runat="server" Text="Dodaj pacjęta"></asp:Label>
                </div>

            </asp:DynamicHyperLink>

            <asp:DynamicHyperLink ID="dhlEditPatientsData" runat="server" NavigateUrl="~/PatientsData.aspx" >
                
                <div class="imageArrowContainer">
                <asp:Image  ID="Image3" runat="server" ImageUrl = "~/images/arrowRight.jpg" CssClass="imageArrow" />
                <asp:Label ID="lblEditPatientData"  runat="server" Text="Edytuj dane pacjenta"></asp:Label>
                </div>

            </asp:DynamicHyperLink>

            <asp:DynamicHyperLink ID="dhlEditDrData" runat="server" NavigateUrl="~/DrData.aspx" >
                
                <div class="imageArrowContainer">
                <asp:Image  ID="Image4" runat="server" ImageUrl = "~/images/arrowRight.jpg" CssClass="imageArrow" />
                <asp:Label ID="lblEditDrData"  runat="server" Text="Edytuj dane lekarza"></asp:Label>
                </div>

            </asp:DynamicHyperLink>

        </div>

</asp:Content>

