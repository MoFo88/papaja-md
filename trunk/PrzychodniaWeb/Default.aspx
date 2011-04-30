<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath ="~/Site.master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <h1>Super przychodnia</h1>

    <h3>papierz jak mozesz to wrzuc tu jakis stały content</h3>

    <h4>bo ja nie wiem co za informacje mogąbyćna tej glupiej stronie tytułowej</h4>

    <br />

    <div style="width: 400px; border :2px solid, gray; padding: 20px 20px 20px 20px; margin: 50px 50px  50px 50px" >
    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore 
    et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex 
    ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
    Excepteur sint occaecat cupidatat non proident, 
    sunt in culpa qui officia deserunt mollit anim id est laborum
    </div>

    <div style="width: 400px; border :2px solid, black; padding: 20px 20px 20px 20px; margin: 30px 30px  30px 30px" >
    Zaczyna się już u nastolatek

    Na rozwój raka szyjki macicy wpływa wiele różnych 
    czynników. Istnieje wyraźny związek między aktywnością seksualną kobiety a ryzykiem powstania stanu przedrakowego lub raka szyjki macicy.

    Wcześnie rozpoczęte współżycie seksualne i zmiany partnerów ułatwiają infekcje wirusem karcinogennym, przenoszonym drogą płciową. W wielu przypadkach jest on właśnie odpowiedzialny za raka szyjki macicy. Niekontrolowany i wielopartnerski seks zwiększa zagrożenie tą chorobą. Częściej występuje ona u prostytutek niż u mężatek. U dziewic w ogóle się jej nie stwierdza.
    Z reguły ujawnia się w odległym czasie od stosunku seksualnego, podczas którego kobieta została zarażona.
    </div>
    <br />

    <div style="float: none; padding-right: 10px; position: relative;">
    <asp:HyperLink runat="server" >
       <asp:Image runat="server" ImageUrl="~/images/pielegniarka.jpg" Height="500" />
    </asp:HyperLink>
    </div>

</asp:Content>
