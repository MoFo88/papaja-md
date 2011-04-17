<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddNewDoctor.aspx.cs" Inherits="AddNewDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Imię:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbImie" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Nazwisko:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbNazwisko" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Pesel:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbPesel" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Kod pocztowy:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbKodKocztowy" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Miasto:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbMiasto" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Ulica:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbUlica" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Nr domu:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbNrDomu" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Telefon:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbTelefon" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Email:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbEmail" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label10" runat="server" Text="Login:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbLogin" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label11" runat="server" Text="Hasło:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TbPassword" runat="server"></asp:TextBox><br />
        </td>
    </tr>
    </table>
    <%--<tr>
        <td>--%>
            <asp:Panel ID="panelSpecializations" runat="server">
                <asp:CheckBoxList ID="cblSpecializations" runat="server" 
    DataSourceID="ObjectDataSource1" DataTextField="nazwa" DataValueField="id" 
                    RepeatColumns="3" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllSpecjalizations" 
    TypeName="BLL.Repository"></asp:ObjectDataSource>
            </asp:Panel>
    <%--  </td>
    </tr>--%>
    <table>
    <tr>
        <td>
            <asp:Label ID="Label12" runat="server" Text="Nowa specjalizacja:"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbNewSpecialization" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnAddSpecialization" runat="server" Text="Dodaj Specjalizację" 
                onclick="btnAddSpecialization_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="BtnSubmit" runat="server" Text="Zatwierdź" 
                    onclick="BtnSubmit_Click" />
        </td>
    </tr>
    </table>
</asp:Content>

