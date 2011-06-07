<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyReservations.aspx.cs" Inherits="MyReservations" MaintainScrollPositionOnPostback="true"%>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Panel>
        <asp:Panel ID="patientDrDataPanel" runat="server" Visible="true">
            <fieldset>
            <legend>Godziny przyjęć</legend>
                <div class="hours">
                    <table>
                        <tr>
                            <th>
                                Poniedziałek
                            </th>
                            <th>
                                Wtorek
                            </th>
                            <th>
                                Środa
                            </th>
                            <th>
                                Czwartek
                            </th>
                            <th>
                                Piątek
                            </th>
                            <th>
                                Sobota
                            </th>
                            <th>
                                Niedziela
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDay1" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDay2" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDay3" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDay4" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDay5" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDay6" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDay7" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </asp:Panel>
    <asp:Panel ID="panelDateChoose" runat="server" Visible="true" CssClass="hoursReservation">
        <h3>
            Wybór tygodnia:</h3>
        <p>
            <asp:Button ID="btnPrevWeek" runat="server" Font-Bold="False" OnClick="btnPrevWeek_Click"
                Text="&lt;&lt;" ToolTip="Poprzedni tydzień" />
            <asp:TextBox ID="tbFirstDayOfWeek" runat="server" ReadOnly="True"></asp:TextBox>
            -<asp:TextBox ID="tbLastDayOfWeek" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="btnNextWeek" runat="server" Font-Bold="False" OnClick="btnNextWeek_Click"
                Text="&gt;&gt;" ToolTip="Następny tydzień" />
        </p>
        <asp:Panel ID="panelDatesTable" Style="float: left;" runat="server">
        </asp:Panel>
    </asp:Panel>
</asp:Content>

