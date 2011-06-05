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
            OnRowDeleted="gridViewSpecializations_RowDeleted" CssClass="gridView" PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" OnRowUpdated="gridViewSpecializations_RowUpdated"
            OnRowDataBound="gridViewSpecializations_RowDataBound">
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <Columns>
                <%--<asp:BoundField HeaderText="id" DataField="id" SortExpression="id" 
                InsertVisible="False" ReadOnly="True"  />--%>
                <asp:TemplateField HeaderText="Nazwa" SortExpression="Nazwa">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nazwa") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbName" runat="server" Text='<%# Bind("nazwa") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="tbNameRequired" runat="server" ControlToValidate="tbName"
                            CssClass="failureNotification" ErrorMessage="Nazwa jest wymagana." ToolTip="Nazwa jest wymagana."
                            ValidationGroup="specializationsDataValidationGroup">*</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/delete.png"
                    ControlStyle-Width="25" ItemStyle-Width="35" ItemStyle-HorizontalAlign="Center" />
                <asp:CommandField ShowEditButton="True" ValidationGroup="specializationsDataValidationGroup"
                    ButtonType="Image" EditImageUrl="~/images/Edit.png" UpdateImageUrl="~/images/update4.png"
                    CancelImageUrl="~/images/cancel.png" ControlStyle-Width="25" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="35" ItemStyle-Wrap="false" />
            </Columns>
            <PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>
    <asp:LinqDataSource ID="ldsSpec" runat="server" OnSelecting="ldsSpec_Selecting"
        ContextTypeName="DAL.PrzychodniaDataClassesDataContext" TableName="Specjalizacjas"
        EnableDelete="true" EnableUpdate="true" OnDeleting="ldsSpec_Deleting" EntityTypeName="Specjalizacja"
        OnUpdating="ldsSpec_Updating">
    </asp:LinqDataSource>
</asp:Content>
