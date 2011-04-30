<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddNewPatient.aspx.cs" Inherits="AddNewPatient" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


<asp:Panel ID="panelAddPatient" runat="server" CssClass="collapsePanel">
          
            <div class="accountInfo">

            <asp:ValidationSummary 
                                ID="addPatientValidationSummary" 
                                runat="server" 
                                CssClass="failureNotification" 
                                ValidationGroup="addPatientValidationGroup"/>

                <fieldset>
                    <legend>Dodaj pacjęta</legend>
                    <p>
                        <asp:Label ID="lblName_" runat="server">Imię:</asp:Label>
                        <asp:TextBox ID="tbName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator 
                                            ID="tbNameRequiredFieldValidator" 
                                            runat="server" 
                                            ControlToValidate="tbName" 
                                            CssClass="failureNotification" 
                                            ErrorMessage="Imię jest wymagane." 
                                            ToolTip="Imię jest wymagane." 
                                            ValidationGroup="addPatientValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblSurname_" runat="server">Nazwisko:</asp:Label>
                        <asp:TextBox ID="tbSurname" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator 
                                            ID="tbSurnameRequiredFieldValidator" 
                                            runat="server" 
                                            ControlToValidate="tbSurname" 
                                            CssClass="failureNotification" 
                                            ErrorMessage="Nazwisko jest wymagane." 
                                            ToolTip="Nazwisko jest wymagane." 
                                            ValidationGroup="addPatientValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblPesel_" runat="server">Pesel:</asp:Label>
                        <asp:TextBox ID="tbPesel" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="lblPhone_" runat="server">Telefon:</asp:Label>
                        <asp:TextBox ID="tbPhone" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                    
                    <p>
                        <asp:Label ID="lblStreet_" runat="server">Ulica:</asp:Label>
                        <asp:TextBox ID="tbStreet" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="lblStreetNr_" runat="server">Numer domu:</asp:Label>
                        <asp:TextBox ID="tbStreetNr" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="lblPostalCode_" runat="server">Kod pocztowy:</asp:Label>
                        <asp:TextBox ID="tbPostalCode" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator 
                                            ID="tbPostalCodeRegularExpressionValidator" 
                                            runat="server" 
                                            ToolTip="Błedny kod pocztowy"
                                            ControlToValidate="tbPostalCode" 
                                            CssClass="failureNotification"
                                            ValidationGroup="addPatientValidationGroup"
                                            ErrorMessage="Błedny kod pocztowy." 
                                            ValidationExpression="\d{2}-\d{3}">*</asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblCity_" runat="server">Miasto:</asp:Label>
                        <asp:TextBox ID="tbCity" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                     
                    <p>
                        <asp:Label ID="lblInsurance_" runat="server">Ubezpieceznie:</asp:Label>
                        <asp:TextBox ID="tbInsurance" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>

                    <p>
                        &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <asp:CheckBox ID="cbHasDr" runat="server" Text="Wybierz lekarza" 
                            oncheckedchanged="cbHasDr_CheckedChanged" AutoPostBack="true" />&nbsp;
                        <asp:DropDownList ID="ddlDrList" runat="server">
                        
                        </asp:DropDownList>
                        </ContentTemplate>
                        </asp:UpdatePanel>

                        <p>
                            <asp:Label ID="lblAddMessage" runat="server" Text=""></asp:Label>
                        </p>

                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="btnSubmitEdit"  runat="server" Text="Dodaj"  
                        ValidationGroup="addPatientValidationGroup" onclick="btnSubmitEdit_Click" />
                </p>
            </div>

        </asp:Panel>


</asp:Content>

