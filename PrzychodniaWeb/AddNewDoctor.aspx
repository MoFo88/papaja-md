<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddNewDoctor.aspx.cs" Inherits="AddNewDoctor" %>
<%@ MasterType VirtualPath ="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="accountInfo">
        <asp:ValidationSummary ID="addSpecValidationSummary" runat="server" 
            CssClass="failureNotification" ValidationGroup="addSpecValidationGroup" />
        <asp:ValidationSummary ID="addDataValidationSummary" runat="server" 
            CssClass="failureNotification" ValidationGroup="addDataValidationGroup" />
        <fieldset>
            <legend>Wprowadź dane</legend>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Imię:"></asp:Label>
                <asp:TextBox ID="tbImie" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="tbImieRequiredFieldValidator" runat="server" 
                    ControlToValidate="tbImie" CssClass="failureNotification" 
                    ErrorMessage="Imię jest wymagane." ToolTip="Imię jest wymagane." 
                    ValidationGroup="addDataValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Nazwisko:"></asp:Label>
                <asp:TextBox ID="tbNazwisko" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="tbNazwiskoRequiredFieldValidator" 
                    runat="server" ControlToValidate="tbNazwisko" CssClass="failureNotification" 
                    ErrorMessage="Nazwisko jest wymagane." ToolTip="Nazwisko jest wymagane." 
                    ValidationGroup="addDataValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Pesel:"></asp:Label>
                <asp:TextBox ID="tbPesel" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Kod pocztowy:"></asp:Label>
                <asp:TextBox ID="tbKodPocztowy" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RegularExpressionValidator ID="tbKodPocztowyRegularExpressionValidator" 
                    runat="server" CssClass="failureNotification" 
                    ErrorMessage="Błędny kod pocztowy." 
                    ValidationGroup="addDataValidationGroup" ControlToValidate="tbKodPocztowy" 
                    ToolTip="Błędny kod pocztowy." ValidationExpression="\d{2}-\d{3}">*</asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:Label ID="Label5" runat="server" Text="Miasto:"></asp:Label>
                <asp:TextBox ID="tbMiasto" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label6" runat="server" Text="Ulica:"></asp:Label>
                <asp:TextBox ID="tbUlica" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label7" runat="server" Text="Nr domu:"></asp:Label>
                <asp:TextBox ID="tbNrDomu" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label8" runat="server" Text="Telefon:"></asp:Label>
                <asp:TextBox ID="tbTelefon" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label9" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="tbEmail" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RegularExpressionValidator ID="tbEmailRegularExpressionValidator" 
                    runat="server" ControlToValidate="tbEmail" CssClass="failureNotification" 
                    ErrorMessage="Błędny adres e-mail." ToolTip="Błędny adres e-mail." 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="addDataValidationGroup">*</asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:Label ID="Label10" runat="server" Text="Login:"></asp:Label>
                <asp:TextBox ID="tbLogin" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="tbLoginRequiredFieldValidator" runat="server" 
                    ErrorMessage="Login jest wymagany." ControlToValidate="tbLogin" 
                    CssClass="failureNotification" ToolTip="Login jest wymagany." 
                    ValidationGroup="addDataValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="Label11" runat="server" Text="Hasło:"></asp:Label>
                <asp:TextBox ID="tbPassword" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="tbPasswordRequiredFieldValidator" runat="server" 
                    ErrorMessage="Hasło jest wymagane." ControlToValidate="tbPassword" 
                    CssClass="failureNotification" ToolTip="Hasło jest wymagane." 
                    ValidationGroup="addDataValidationGroup">*</asp:RequiredFieldValidator>
            </p>

            <%--<asp:Panel ID="panelSpecializations" runat="server">--%>
            <p>
                <asp:CheckBoxList ID="cblSpecializations" runat="server" 
                    DataTextField="nazwa" DataValueField="id" 
                    RepeatColumns="3" RepeatDirection="Horizontal"></asp:CheckBoxList>
                <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllSpecjalizations" 
                    TypeName="BLL.Repository"></asp:ObjectDataSource>--%><%-- </asp:Panel>--%>
           </p>
            <p class="submitSpecButton">
                <asp:Label ID="Label12" runat="server" Text="Nowa specjalizacja:"></asp:Label>
                <asp:TextBox ID="tbNewSpecialization" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="tbNewSpecializationRequiredFieldValidator" 
                    runat="server" ControlToValidate="tbNewSpecialization" 
                    CssClass="failureNotification" ErrorMessage="Nazwa specjalności jest wymagana." 
                    ToolTip="Nazwa specjalności jest wymagana." 
                    ValidationGroup="addSpecValidationGroup">*</asp:RequiredFieldValidator>
                <asp:Button ID="btnAddSpecialization" runat="server" Text="Dodaj Specjalizację" 
                    onclick="btnAddSpecialization_Click" 
                    ValidationGroup="addSpecValidationGroup" />
            </p>
            <p class="submitButton">
                <asp:Button ID="BtnSubmit" runat="server" Text="Zatwierdź" 
                        onclick="BtnSubmit_Click" ValidationGroup="addDataValidationGroup" />
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </p>
        </fieldset>
    </div>
</asp:Content>

