<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientsData.aspx.cs" Inherits="PatientsData" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="DAL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <asp:ValidationSummary 
        ID="editPasswordValidationSummary" 
        runat="server" 
        CssClass="failureNotification" 
        ValidationGroup="editPatientDataValidationGroup"/>

    <div class="patientGrid">
    <asp:GridView 
        ID="gridViewPatients" 
        runat="server" 
        DataSourceID="LinqDataSource1" 
        AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False" 
        DataKeyNames="id" 
        onrowdeleted="gridViewPatients_RowDeleted"
        CssClass="gridView"  
        PagerStyle-CssClass="pgr"  
        AlternatingRowStyle-CssClass="alt" 
        onrowupdated="gridViewPatients_RowUpdated" 
        onrowdatabound="gridViewPatients_RowDataBound" 
        onrowupdating="gridViewPatients_RowUpdating"
        
        >
    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns >
            <%--<asp:BoundField HeaderText="id" DataField="id" SortExpression="id" 
                InsertVisible="False" ReadOnly="True"  />--%>
            <asp:TemplateField HeaderText="imie" SortExpression="imie">
            <ItemTemplate>
                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("imie") %>'></asp:Label>
            </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tbName" runat="server" Text='<%# Bind("imie") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="tbNameRequired" 
                        runat="server" 
                        ControlToValidate="tbName" 
                        CssClass="failureNotification" 
                        ErrorMessage="Imię jest wymagane." 
                        ToolTip="Imię jest wymagane." 
                        ValidationGroup="editPatientDataValidationGroup"
                        >*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="nazwisko" SortExpression="nazwisko">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("nazwisko") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tbSurname" runat="server" Text='<%# Bind("nazwisko") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="tbSurnameRequired" 
                        runat="server" 
                        ControlToValidate="tbSurname" 
                        CssClass="failureNotification" 
                        ErrorMessage="Nazwisko jest wymagane." 
                        ToolTip="Nazwisko jest wymagane." 
                        ValidationGroup="editPatientDataValidationGroup"
                        >*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="pesel" SortExpression="pesel">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("pesel") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tbPesel" runat="server" Text='<%# Bind("pesel") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="tbPeselRequired" 
                        runat="server" 
                        ControlToValidate="tbPesel" 
                        CssClass="failureNotification" 
                        ErrorMessage="Pesel jest wymagany." 
                        ToolTip="Pesel jest wymagany." 
                        ValidationGroup="editPatientDataValidationGroup"
                        >*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="kod_pocztowy" SortExpression="kod_pocztowy">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("kod_pocztowy") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tbPostalCode" runat="server" Text='<%# Bind("kod_pocztowy") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator 
                                        ID="tbEditPostalCodeRegularExpressionValidator" 
                                        runat="server" 
                                        ToolTip="Błedny kod pocztowy"
                                        ControlToValidate="tbPostalCode" 
                                        CssClass="failureNotification"
                                        ValidationGroup="editPatientDataValidationGroup"
                                        ErrorMessage="Błedny kod pocztowy." 
                                        ValidationExpression="\d{2}-\d{3}">*</asp:RegularExpressionValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="miasto" SortExpression="miasto">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("miasto") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("miasto") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ulica" SortExpression="ulica">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("ulica") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ulica") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="nr_domu" SortExpression="nr_domu">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("nr_domu") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("nr_domu") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="telefon" SortExpression="telefon">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("telefon") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("telefon") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ubezpieczenie" SortExpression="ubezpieczenie">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("ubezpieczenie") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("ubezpieczenie") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Lekarz rodzinny"  SortExpression="id_lek" >
                <ItemTemplate>
                    <%# GetDrFullName( Eval("id_lek") ) %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlEditDr" runat="server" DataSourceID="odsDr" 
                        DataTextField="Name" DataValueField="id">
                    </asp:DropDownList>
                </EditItemTemplate>
           </asp:TemplateField>
            <asp:CommandField 
                ShowDeleteButton="True"
                ButtonType="Image"
                DeleteImageUrl="~/images/delete.png"
                ControlStyle-Height="25"

                 />
            <asp:CommandField 
                ShowEditButton="True" 
                ValidationGroup="editPatientDataValidationGroup" 
                ButtonType="Image"
                EditImageUrl="~/images/Edit.png"
                UpdateImageUrl="~/images/update4.png"
                CancelImageUrl="~/images/cancel.png"
                ControlStyle-Height="25"
                
                />
        </Columns>

    <PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>
    </div>

    <asp:ObjectDataSource ID="odsDr" TypeName="Root"   runat="server" 
        SelectMethod="GetAllDrDdList" >
    </asp:ObjectDataSource>

    <asp:LinqDataSource 
        ID="LinqDataSource1"  
        runat="server" 
        onselecting="LinqDataSource1_Selecting"
        ContextTypeName="DAL.PrzychodniaDataClassesDataContext"
        TableName="Uzytkowniks"
        EntityTypeName="Pacjent" 
        EnableDelete="true"
        EnableUpdate="true"
        ondeleting="LinqDataSource1_Deleting" 
        onupdating="LinqDataSource1_Updating"
        >
    </asp:LinqDataSource>
    

</asp:Content>

