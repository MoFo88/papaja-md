<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SpecializationsData.aspx.cs" Inherits="SpecializationsData" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="DAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ValidationSummary ID="specializationsDataValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="specializationsDataValidationGroup" />
    <div class="patientGrid">
        <asp:GridView ID="gridViewSpecializations" runat="server" DataSourceID="ldsSpec"
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id"
            OnRowDeleted="gridViewSpecializations_RowDeleted" CssClass="gridView" agerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" OnRowUpdated="gridViewSpecializations_RowUpdated"
            OnRowDataBound="gridViewSpecializations_RowDataBound">
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <Columns>
                <%--<asp:BoundField HeaderText="id" DataField="id" SortExpression="id" 
                InsertVisible="False" ReadOnly="True"  />--%>
                <asp:TemplateField HeaderText="nazwa" SortExpression="nazwa">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nazwa") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbName" runat="server" Text='<%# Bind("nazwa") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="tbNameRequiredFieldValidator" runat="server" ErrorMessage="Nazwa jest wymagana."
                            ToolTip="Nazwa jest wymagana" Text="*" CssClass="failureNotification" ControlToValidate="tbName" ValidationGroup="specializationsDataValidationGroup"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/delete.png"
                    ControlStyle-Width="25" ItemStyle-Width="35" ItemStyle-HorizontalAlign="Center">
                    <ControlStyle Width="25px"></ControlStyle>
                    <ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
                </asp:CommandField>
                <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="~/images/Edit.png"
                    UpdateImageUrl="~/images/update4.png" CancelImageUrl="~/images/cancel.png" ControlStyle-Width="25"
                    ItemStyle-Width="35" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                    ValidationGroup="specializationsDataValidationGroup">
                    <ControlStyle Width="25px"></ControlStyle>
                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="35px"></ItemStyle>
                </asp:CommandField>
            </Columns>
            <PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>
    <asp:LinqDataSource ID="ldsSpec" runat="server" OnSelecting="ldsSpec_Selecting" ContextTypeName="DAL.PrzychodniaDataClassesDataContext"
        TableName="Specjalizacjas" EnableDelete="True" EnableUpdate="True" OnDeleting="ldsSpec_Deleting"
        EntityTypeName="Specjalizacja" OnUpdating="ldsSpec_Updating">
    </asp:LinqDataSource>
    <div class="accountInfo">
        <fieldset>
            <legend>Nowa specjalizacja</legend>
            <p class="submitSpecButton">
                <asp:Label ID="Label12" runat="server" Text="Nazwa:"></asp:Label>
                <asp:TextBox ID="tbNewSpecialization" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="tbNewSpecializationRequiredFieldValidator" runat="server"
                    ControlToValidate="tbNewSpecialization" CssClass="failureNotification" ErrorMessage="Nazwa specjalności jest wymagana."
                    ToolTip="Nazwa specjalności jest wymagana." ValidationGroup="addSpecValidationGroup">*</asp:RequiredFieldValidator>
                <asp:Button ID="btnAddSpecialization" runat="server" Text="Dodaj Specjalizację" OnClick="btnAddSpecialization_Click"
                    ValidationGroup="addSpecValidationGroup" />
            </p>
            <p class="submitSpecButton">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </p>
        </fieldset>
    </div>
</asp:Content>
