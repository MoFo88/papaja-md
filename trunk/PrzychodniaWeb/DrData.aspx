<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DrData.aspx.cs" Inherits="DrData" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        CssClass="failureNotification" 
        ValidationGroup="editDrDataValidationGroup"/>
    
    <div class="drGrid">    
    <asp:GridView 
        ID="gridViewDrs" 
        runat="server"
        AllowPaging="True" 
        AllowSorting="True" 
        DataKeyNames="id" 
        CssClass="gridView"  
        PagerStyle-CssClass="pgr"  
        AlternatingRowStyle-CssClass="alt" 
        DataSourceID="LinqDataSource1"
        AutoGenerateColumns="False" 
        onrowdeleted="gridViewDrs_RowDeleted" 
        onrowupdated="gridViewDrs_RowUpdated" 
        onrowediting="gridViewDrs_RowEditing"
        >
    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                ReadOnly="True" SortExpression="id" />
            <asp:TemplateField HeaderText="login" SortExpression="login">
                <EditItemTemplate>
                    <asp:TextBox ID="tbLogin" runat="server" Text='<%# Bind("login") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="tbLoginRequired" 
                        runat="server" 
                        ControlToValidate="tbLogin" 
                        CssClass="failureNotification" 
                        ErrorMessage="Login jest wymagany." 
                        ToolTip="Login jest wymagany." 
                        ValidationGroup="editDrDataValidationGroup"
                        >*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLogin" runat="server" Text='<%# Bind("login") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="imie" SortExpression="imie">
                <EditItemTemplate>
                    <asp:TextBox ID="tbName" runat="server" Text='<%# Bind("imie") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="tbNameRequired" 
                        runat="server" 
                        ControlToValidate="tbName" 
                        CssClass="failureNotification" 
                        ErrorMessage="Imię jest wymagane." 
                        ToolTip="Imię jest wymagane." 
                        ValidationGroup="editDrDataValidationGroup"
                        >*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("imie") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="nazwisko" SortExpression="nazwisko">
                <EditItemTemplate>
                    <asp:TextBox ID="tbSurname" runat="server" Text='<%# Bind("nazwisko") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="tbSurnameRequired" 
                        runat="server" 
                        ControlToValidate="tbSurname" 
                        CssClass="failureNotification" 
                        ErrorMessage="Nazwisko jest wymagane." 
                        ToolTip="Nazwisko jest wymagane." 
                        ValidationGroup="editDrDataValidationGroup"
                        >*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSurname" runat="server" Text='<%# Bind("nazwisko") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="pesel" SortExpression="pesel">
                <EditItemTemplate>
                    <asp:TextBox ID="tbPesel" runat="server" Text='<%# Bind("pesel") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="tbPeselRequired" 
                        runat="server" 
                        ControlToValidate="tbPesel" 
                        CssClass="failureNotification" 
                        ErrorMessage="Pesel jest wymagany." 
                        ToolTip="Pesel jest wymagany." 
                        ValidationGroup="editDrDataValidationGroup"
                        >*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPesel" runat="server" Text='<%# Bind("pesel") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="kod_pocztowy" SortExpression="kod_pocztowy">
                <EditItemTemplate>
                    <asp:TextBox ID="tbPostalCode" runat="server" Text='<%# Bind("kod_pocztowy") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator 
                                        ID="tbPostalCodeRegularExpressionValidator" 
                                        runat="server" 
                                        ToolTip="Błedny kod pocztowy"
                                        ControlToValidate="tbPostalCode" 
                                        CssClass="failureNotification"
                                        ValidationGroup="editDrDataValidationGroup"
                                        ErrorMessage="Błedny kod pocztowy." 
                                        ValidationExpression="\d{2}-\d{3}">*</asp:RegularExpressionValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPostalCode" runat="server" Text='<%# Bind("kod_pocztowy") %>'></asp:Label>
                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="miasto" HeaderText="miasto" 
                SortExpression="miasto" />
            <asp:BoundField DataField="ulica" HeaderText="ulica" SortExpression="ulica" />
            <asp:BoundField DataField="nr_domu" HeaderText="nr_domu" 
                SortExpression="nr_domu" />
            <asp:BoundField DataField="telefon" HeaderText="telefon" 
                SortExpression="telefon" />
            <asp:TemplateField HeaderText="email" SortExpression="email">
                <EditItemTemplate>
                    <asp:TextBox ID="tbEmail" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator 
                                        ID="tbEmailRegularExpressionValidator" 
                                        runat="server"
                                        ControlToValidate="tbEmail" 
                                        ValidationGroup="editDataValidationGroup"
                                        ToolTip="Błędny adres email."
                                        CssClass="failureNotification"
                                        ErrorMessage="Błędny adres email." 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:CommandField 
                ShowDeleteButton="True"
                ButtonType="Image"
                DeleteImageUrl="~/images/delete.png"
                ControlStyle-Width="25"
                 />

            <asp:CommandField 
                ShowEditButton="True" 
                ButtonType="Image"
                EditImageUrl="~/images/Edit.png"
                UpdateImageUrl="~/images/update4.png"
                CancelImageUrl="~/images/cancel.png"
                ControlStyle-Width="25"
                ValidationGroup="editDrDataValidationGroup" />
            
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>
    </div>
    <asp:LinqDataSource 
        ID="LinqDataSource1" 
        runat="server"
        TableName="Uzytkowniks"
        EntityTypeName="Lekarz" 
        onselecting="LinqDataSource1_Selecting" 
        ContextTypeName="DAL.PrzychodniaDataClassesDataContext" 
        EnableDelete="True" EnableUpdate="True" 
        ondeleting="LinqDataSource1_Deleting" 
        onupdating="LinqDataSource1_Updating"
        >
    </asp:LinqDataSource>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <br />
    <asp:Panel ID="panelEditPassword" runat="server" CssClass="collapsePanel">
            <div class="accountInfo">

            <asp:ValidationSummary 
                                ID="editPasswordValidationSummary" 
                                runat="server" 
                                CssClass="failureNotification" 
                                ValidationGroup="editPasswordValidationGroup"/>

            <fieldset>
                <legend>Zmień hasło</legend>
                <p>
                    <asp:Label ID="lblPassword_" runat="server">Hasło:</asp:Label>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                            ID="passwordRequired" 
                            runat="server" 
                            ControlToValidate="tbPassword" 
                            CssClass="failureNotification" 
                            ErrorMessage="Hasło jest wymagane." 
                            ToolTip="Hasło jest wymagane." 
                            ValidationGroup="editPasswordValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblConfPassword_" runat="server">Potwierdz hasło:</asp:Label>
                    <asp:TextBox ID="tbConfPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                            ID="confirmPasswordRequiredFieldValidator" 
                            runat="server" 
                            ControlToValidate="tbConfPassword" 
                            CssClass="failureNotification" 
                            ErrorMessage="Potwierdzenie Hasła jest wymagane." 
                            ToolTip="Potwierdzeie hasła jest wymagane." 
                            ValidationGroup="editPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator 
                            ID="passwordCompareValidator" 
                            runat="server" 
                            ErrorMessage="Hasła nie są identyczne." 
                            ValidationGroup="editPasswordValidationGroup" 
                            ControlToValidate="tbPassword"
                            ControlToCompare="tbConfPassword"
                            CssClass="failureNotification"
                            ToolTip="Hasła nie są identyczne"
                            >*</asp:CompareValidator>
                </p>

                <p>
                    <asp:Label ID="lblPasswordChangeMessage" runat="server" Text=""></asp:Label>
                </p>
                </fieldset>
                <p class="submitButton">
                <asp:Button 
                    ID="btnChangePassword" 
                    runat="server" 
                    Text="Edytuj" 
                    ValidationGroup = "editPasswordValidationGroup" 
                    onclick="btnChangePassword_Click1"
                    CausesValidation="true"
                    />
                </p>
            </div>
        </asp:Panel>
  
        <asp:Panel ID="panelEditSpec" runat="server" CssClass="collapsePanel">

            <div class="cbSpec">
            <fieldset>
                <legend>Specjalizacje</legend>
                <asp:Panel ID="panelSpecializations" runat="server">
                <asp:CheckBoxList 
                            ID="cblSpecializations" 
                            runat="server" 
                            DataTextField="nazwa" 
                            DataValueField="id" 
                            RepeatColumns="3" 
                            RepeatDirection="Horizontal">
                </asp:CheckBoxList>
                </asp:Panel>

                <p>
                    <asp:Label ID="lblSpecMessage" runat="server" Text=""></asp:Label>
                </p>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnEditSpec" runat="server" Text="Edytuj" 
                        onclick="btnEditSpec_Click" />
            </p>
        </div>      
        </asp:Panel>


</asp:Content>

