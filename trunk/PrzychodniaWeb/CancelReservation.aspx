<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CancelReservation.aspx.cs" Inherits="CancelReservation" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel ID="patientSearchPanel" runat="server">
        <asp:ValidationSummary ID="PeselValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="PeselValidationGroup" />
        <div class="accountInfo" style="float: left; height: 166px;">
            <fieldset class="fieldsetReservation">
                <legend>Wyszukaj pacjenta</legend>
                <p>
                    <asp:Label ID="Label2" runat="server" Text="Pesel:"></asp:Label>
                    <asp:TextBox ID="tbPesel" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="tbPeselRegularExpressionValidator" runat="server"
                        ControlToValidate="tbPesel" CssClass="failureNotification" Display="Dynamic"
                        ErrorMessage="Podana wartość nie jest poprawym numerem PESEL." ToolTip="Podana wartość nie jest poprawym numerem PESEL."
                        ValidationExpression="\d{11}" ValidationGroup="PeselValidationGroup">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="tbPeselRequiredFieldValidator" runat="server" ControlToValidate="tbPesel"
                        CssClass="failureNotification" Display="Dynamic" ErrorMessage="Numer PESEL jest wymagany."
                        ToolTip="Numer PESEL jest wymagany." ValidationGroup="PeselValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p class="submitButton">
                    <asp:Button ID="btnSearchPatient" runat="server" Text="Wyszukaj Pacjenta" OnClick="btnSearchPatient_Click"
                        ValidationGroup="PeselValidationGroup" />
                </p>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="patientDataPanel" runat="server" Visible="false">
        <div class="accountInfo" style="float: left; padding-left: 40px;">
            <fieldset class="fieldsetReservation">
                <legend>Dane pacjenta:</legend>
                <asp:Label ID="lblName_" runat="server" Text="Imię: "></asp:Label>
                <asp:Label ID="lblName" runat="server"></asp:Label><br />
                <asp:Label ID="lblSurname_" runat="server" Text="Nazwisko: "></asp:Label>
                <asp:Label ID="lblSurmane" runat="server"></asp:Label><br />
                <asp:Label ID="lblPhone_" runat="server" Text="Telefon: "></asp:Label>
                <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                <asp:Label ID="lblAdres_" runat="server" Text="Adres: "></asp:Label>
                <asp:Label ID="lblAdres" runat="server"></asp:Label><br />
                <asp:Label ID="lblDrName_" runat="server" Text="Lekarz: "></asp:Label>
                <asp:Label ID="lblDrName" runat="server"></asp:Label>
            </fieldset>
        </div>
    </asp:Panel>
    <div class="accountInfo">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <asp:Panel ID="patientsReservationsPanel" runat="server" Visible="false">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
