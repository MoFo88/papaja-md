<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="WorkHours.aspx.cs" Inherits="WorkHours" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel ID="drChoosePanel" runat="server">
        <div class="accountInfo">
            <fieldset>
                <legend>Wybierz lekarza</legend>
                <p>
                    <asp:Label ID="lblDrList" runat="server" Text="Lista lekarzy:"></asp:Label><br />
                    <asp:DropDownList ID="ddlDrList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDrList_SelectedIndexChanged">
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="lblNoDr" runat="server" Text=""></asp:Label>
                </p>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="workHoursPanel" runat="server" Visible="false">
        <fieldset>
            <legend>Godziny przyjęć lekarza</legend>
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
                    <tr style="vertical-align:top;">
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
    <asp:Panel ID="editWorkHoursPanel" runat="server" Visible="false" CssClass="accountInfo">
    </asp:Panel>
</asp:Content>
