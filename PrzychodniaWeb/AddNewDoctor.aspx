<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddNewDoctor.aspx.cs" Inherits="AddNewDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Imię:"></asp:Label><asp:TextBox ID="TbImie" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server" Text="Nazwisko:"></asp:Label><asp:TextBox ID="TbNazwisko" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label3" runat="server" Text="Pesel:"></asp:Label><asp:TextBox ID="TbPesel" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label4" runat="server" Text="Kod pocztowy:"></asp:Label><asp:TextBox ID="TbKodKocztowy" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label5" runat="server" Text="Miasto:"></asp:Label><asp:TextBox ID="TbMiasto" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label6" runat="server" Text="Ulica:"></asp:Label><asp:TextBox ID="TbUlica" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label7" runat="server" Text="Nr domu:"></asp:Label><asp:TextBox ID="TbNrDomu" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label8" runat="server" Text="Telefon:"></asp:Label><asp:TextBox ID="TbTelefon" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label9" runat="server" Text="Email:"></asp:Label><asp:TextBox ID="TbEmail" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label10" runat="server" Text="Login:"></asp:Label><asp:TextBox ID="TbLogin" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label11" runat="server" Text="Hasło:"></asp:Label><asp:TextBox ID="TbPassword" runat="server"></asp:TextBox><br />
    <asp:DropDownList ID="DropDownList1" runat="server" >
    </asp:DropDownList><br />
    <asp:Button ID="BtnSubmit" runat="server" Text="Zatwierdź" 
        onclick="BtnSubmit_Click" />
</asp:Content>

