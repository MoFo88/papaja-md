<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AddNewReservation.aspx.cs" Inherits="AddNewReservation" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel ID="patientSearchPanel" runat="server">
        <asp:ValidationSummary ID="PeselValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="PeselValidationGroup" />
        <div class="accountInfo" style="float: left; height: 166px;">
            <fieldset class="fieldsetReservation">
                <legend>Wyszukaj pacjenta</legend>
                <p>
                    <asp:Label ID="Label2" runat="server" Text="Pesel:"></asp:Label>
                    <asp:TextBox ID="tbPesel" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="tbPeselRegularExpressionValidator" runat="server"
                        ControlToValidate="tbPesel" CssClass="failureNotification" Display="Dynamic"
                        ErrorMessage="Podana wartość nie jest poprawym numerem PESEL." ToolTip="Podana wartość nie jest poprawym numerem PESEL."
                        ValidationExpression="\d{11}" ValidationGroup="PeselValidationGroup">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="tbPeselRequiredFieldValidator" runat="server" ControlToValidate="tbPesel"
                        CssClass="failureNotification" Display="Dynamic" ErrorMessage="Numer PESEL jest wymagany."
                        ToolTip="Numer PESEL jest wymagany." ValidationGroup="PeselValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p class="submitButton">
                    <asp:Button ID="btnSearchPatient" runat="server" Text="Wyszukaj Pacjenta" OnClick="btnSearchPatient_Click"
                        ValidationGroup="PeselValidationGroup" />
                </p>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="patientDataPanel" runat="server" Visible="false">
        <div class="accountInfo" style="float: left; padding-left: 40px;">
            <fieldset class="fieldsetReservation">
                <legend>Dane pacjenta:</legend>
                <asp:Label ID="lblName_" runat="server" Text="Imię: "></asp:Label>
                <asp:Label ID="lblName" runat="server"></asp:Label><br />
                <asp:Label ID="lblSurname_" runat="server" Text="Nazwisko: "></asp:Label>
                <asp:Label ID="lblSurmane" runat="server"></asp:Label><br />
                <asp:Label ID="lblPesel_" runat="server" Text="Pesel: "></asp:Label>
                <asp:Label ID="lblPesel" runat="server"></asp:Label><br />
                <asp:Label ID="lblPhone_" runat="server" Text="Telefon: "></asp:Label>
                <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                <asp:Label ID="lblAdres_" runat="server" Text="Adres: "></asp:Label>
                <asp:Label ID="lblAdres" runat="server"></asp:Label>
            </fieldset>
        </div>
    </asp:Panel>
    <br />
    <div class="accountInfo">
        <asp:Label ID="lblNoDr" runat="server" Text=""></asp:Label>
        <asp:Panel ID="patientDrDataPanel" runat="server" Visible="false">
            <fieldset>
                <legend>Dane lekarza: </legend>
                <asp:Label ID="lblDrName_" runat="server" Text="Imię: "></asp:Label>
                <asp:Label ID="lblDrName" runat="server"></asp:Label><br />
                <asp:Label ID="lblDrSurname_" runat="server" Text="Nazwisko: "></asp:Label>
                <asp:Label ID="lblDrSurname" runat="server"></asp:Label>
                <br />
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
    </div>
    <asp:Panel ID="panelDateChoose" runat="server" Visible="False" 
        CssClass="hoursReservation">

            <h3>
                Wybór terminu wizyty:</h3>
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
        <asp:Panel ID="panelReservationData" Style="float: left; padding-left: 40px; padding-top: 45px"
            runat="server" Visible="False">
            <asp:ValidationSummary ID="reservationSubmitValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="reservationSubmitValidationGroup" />
            <div class="accountInfo">
                <fieldset>
                    <legend>Dane rezerwacji:</legend>
                    <p>
                        <asp:Label ID="lblResDate" runat="server" Text="Data: "></asp:Label>
                        <asp:TextBox ID="tbResDate" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="tbResDateRequiredFieldValidator" runat="server" ControlToValidate="tbResDate"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="Data jest wymagana."
                            ToolTip="Data jest wymagana." ValidationGroup="reservationSubmitValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="tbResDateRegularExpressionValidator" runat="server"
                            ControlToValidate="tbResDate" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="Data powinna być podana w formacie RRRR-MM-DD" ToolTip="Data powinna być podana w formacie RRRR-MM-DD"
                            ValidationExpression="\d{4}-\d{2}-\d{2}" ValidationGroup="reservationSubmitValidationGroup">*</asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblResHourStart" runat="server" Text="Godzina początku: "></asp:Label>
                        <asp:TextBox ID="tbResHourStart" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="tbResHourStartRequiredFieldValidator" runat="server"
                            ControlToValidate="tbResHourStart" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="Godzina rozpoczęcia jest wymagana." ToolTip="Godzina rozpoczęcia jest wymagana."
                            ValidationGroup="reservationSubmitValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="tbResHourStartRegularExpressionValidator" runat="server"
                            ControlToValidate="tbResHourStart" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="Godzina powinna być podana w formacie GG:mm" ToolTip="Godzina powinna być podana w formacie GG:mm"
                            ValidationExpression="\d\d:\d\d" ValidationGroup="reservationSubmitValidationGroup">*</asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblResHourEnd" runat="server" Text="Godzina końca: "></asp:Label>
                        <asp:TextBox ID="tbResHourEnd" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:CompareValidator ID="tbResHourEndCompareValidator" runat="server" ControlToCompare="tbResHourStart"
                            ControlToValidate="tbResHourEnd" CssClass="failureNotification" ErrorMessage="Godzina zakończenia wizyty musi być późniejsza niż godzina rozpoczęcia."
                            Operator="GreaterThanEqual" ToolTip="Godzina zakończenia wizyty musi być późniejsza niż godzina rozpoczęcia."
                            ValidationGroup="reservationSubmitValidationGroup">*</asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="tbResHourEndRequiredFieldValidator" runat="server"
                            ControlToValidate="tbResHourEnd" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="Godzina zakończenia jest wymagana." ToolTip="Godzina zakończenia jest wymagana."
                            ValidationGroup="reservationSubmitValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="tbResHourEndRegularExpressionValidator" runat="server"
                            ControlToValidate="tbResHourEnd" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="Godzina powinna być podana w formacie GG:mm" ToolTip="Godzina powinna być podana w formacie GG:mm"
                            ValidationExpression="\d\d:\d\d" ValidationGroup="reservationSubmitValidationGroup">*</asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblResType" runat="server" Text="Typ: "></asp:Label>
                        <asp:DropDownList ID="ddlResType" runat="server">
                        </asp:DropDownList>
                    </p>
                    <p class="submitButton">
                        <asp:Button ID="btnSubmitReservation" runat="server" Text="Zapisz" OnClick="btnSubmitReservation_Click"
                            ValidationGroup="reservationSubmitValidationGroup" />
                    </p>
                    <p>
                        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                    </p>
                </fieldset>
            </div>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
