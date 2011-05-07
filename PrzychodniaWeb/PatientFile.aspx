<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientFile.aspx.cs" Inherits="PatientFile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Kartoteka pacjenta</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div>
        <h1><asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label></h1>
    </div>


    <p><asp:Label ID="lblPesel_" runat="server" Text="Pesel: "></asp:Label><asp:Label id="lblPesel" runat="server"></asp:Label></p>
    <p><asp:Label ID="lblEnsurance_" runat="server" Text="Ubezpieczenie: "></asp:Label><asp:Label id="lblEnsurance" runat="server"></asp:Label></p>
    <p><asp:Label ID="lblPhone_" runat="server" Text="Telefon: "></asp:Label><asp:Label id="lblPhone" runat="server"></asp:Label></p>
    <p><asp:Label ID="lblLastVisite_" runat="server" Text="Ostatnia wizyta: "></asp:Label><asp:Label id="lblLastVisite" runat="server"></asp:Label></p>
        


    <p>
        
    </p>

</asp:Content>

