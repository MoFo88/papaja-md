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
                    <tr style="vertical-align: top;">
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
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <asp:ValidationSummary ID="workHoursValidationSummary" runat="server" 
        ValidationGroup="workHoursValidationGroup" CssClass="failureNotification" />
    <asp:Panel ID="editWorkHoursPanel" runat="server" Visible="false" CssClass="accountInfo">
    </asp:Panel>
    <asp:ValidationSummary ID="newWorkHoursValidationSummary" runat="server" 
        ValidationGroup="newWorkHoursValidationGroup" CssClass="failureNotification" />
    <asp:Panel ID="newWorkHoursPanel" runat="server" Visible="false" CssClass="accountInfo">
        <fieldset>
            <legend>Nowy termin</legend>Dzień:<br />
            <asp:DropDownList ID="ddlDay" runat="server">
            </asp:DropDownList><br />
            Godziny przyjęcia:<br />
            od:
            <asp:TextBox ID="tbBegin" runat="server" Width="140"></asp:TextBox>
            <asp:RequiredFieldValidator ID="tbBeginRequiredFieldValidator" runat="server"
                ControlToValidate="tbBegin" CssClass="failureNotification" Display="Dynamic"
                ErrorMessage="Godzina rozpoczęcia jest wymagana." ToolTip="Godzina rozpoczęcia jest wymagana."
                ValidationGroup="newWorkHoursValidationGroup">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="tbBeginRegularExpressionValidator" runat="server"
                ControlToValidate="tbBegin" CssClass="failureNotification" Display="Dynamic"
                ErrorMessage="Godzina powinna być podana w formacie GG:mm" ToolTip="Godzina powinna być podana w formacie GG:mm"
                ValidationExpression="\d\d:\d\d" ValidationGroup="newWorkHoursValidationGroup">*</asp:RegularExpressionValidator>
            do:
            <asp:TextBox ID="tbEnd" runat="server" Width="140"></asp:TextBox>
            <asp:CompareValidator ID="tbEndCompareValidator" runat="server" ControlToCompare="tbBegin"
                ControlToValidate="tbEnd" CssClass="failureNotification" ErrorMessage="Godzina końca wizyty musi być późniejsza niż godzina rozpoczęcia."
                Operator="GreaterThanEqual" ToolTip="Godzina końca wizyty musi być późniejsza niż godzina rozpoczęcia."
                ValidationGroup="newWorkHoursValidationGroup">*</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="tbEndRequiredFieldValidator" runat="server" ControlToValidate="tbEnd"
                CssClass="failureNotification" Display="Dynamic" ErrorMessage="Godzina końca jest wymagana."
                ToolTip="Godzina końca jest wymagana." ValidationGroup="newWorkHoursValidationGroup">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="tbEndRegularExpressionValidator" runat="server"
                ControlToValidate="tbEnd" CssClass="failureNotification" Display="Dynamic" ErrorMessage="Godzina powinna być podana w formacie GG:mm"
                ToolTip="Godzina powinna być podana w formacie GG:mm" ValidationExpression="\d\d:\d\d"
                ValidationGroup="newWorkHoursValidationGroup">*</asp:RegularExpressionValidator>
                <p class="submitButton">
                    <asp:Button ID="btnAddNewHours" runat="server" Text="Dodaj" 
                        ValidationGroup="newWorkHoursValidationGroup" onclick="btnAddNewHours_Click"/>
                </p>
                <p>
                    <asp:Label ID="lblAddResult" runat="server" Text=""></asp:Label>
                </p>
        </fieldset>
    </asp:Panel>
</asp:Content>
