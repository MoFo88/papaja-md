<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddNewReservation.aspx.cs" Inherits="AddNewReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="PatientInfo" runat="server">
    <div class="accountInfo">
        <fieldset>
            <legend>Dane Pacjenta</legend>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
                <asp:TextBox ID="tbLogin" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Pesel:"></asp:Label>
                <asp:TextBox ID="tbPesel" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p class="submitButton">
                <asp:Button ID="btnSearchPatient" runat="server" Text="Wyszukaj Pacjenta" 
                    onclick="btnSearchPatient_Click" />
            </p>
        </fieldset>
    </div>
    </asp:Panel>
</asp:Content>

