<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddNewDoctor.aspx.cs" Inherits="AddNewDoctor" %>
<%@ MasterType VirtualPath ="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="accountInfo">
        <fieldset>
            <legend>Edytuj dane</legend>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Imię:"></asp:Label>
                <asp:TextBox ID="tbImie" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Nazwisko:"></asp:Label>
                <asp:TextBox ID="tbNazwisko" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Pesel:"></asp:Label>
                <asp:TextBox ID="tbPesel" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Kod pocztowy:"></asp:Label>
                <asp:TextBox ID="tbKodKocztowy" runat="server" CssClass="textEntry"></asp:TextBox>
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
            </p>
            <p>
                <asp:Label ID="Label10" runat="server" Text="Login:"></asp:Label>
                <asp:TextBox ID="tbLogin" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label11" runat="server" Text="Hasło:"></asp:Label>
                <asp:TextBox ID="tbPassword" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>

            <%--<asp:Panel ID="panelSpecializations" runat="server">--%>
            <p>
                <asp:CheckBoxList ID="cblSpecializations" runat="server" 
                    DataTextField="nazwa" DataValueField="id" 
                    RepeatColumns="3" RepeatDirection="Horizontal"></asp:CheckBoxList>
                <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllSpecjalizations" 
                    TypeName="BLL.Repository"></asp:ObjectDataSource>--%>
           <%-- </asp:Panel>--%>
           </p>
            <p class="submitSpecButton">
                <asp:Label ID="Label12" runat="server" Text="Nowa specjalizacja:"></asp:Label>
                <asp:TextBox ID="tbNewSpecialization" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:Button ID="btnAddSpecialization" runat="server" Text="Dodaj Specjalizację" 
                    onclick="btnAddSpecialization_Click" />
            </p>
            <p class="submitButton">
                <asp:Button ID="BtnSubmit" runat="server" Text="Zatwierdź" 
                        onclick="BtnSubmit_Click" />
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </p>
        </fieldset>
    </div>
</asp:Content>

