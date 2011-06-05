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
        <asp:GridView 
            ID="gridViewSpecializations" 
            runat="server" 
            DataSourceID="ldsSpec"
            AllowPaging="True" 
            AllowSorting="True" 
            AutoGenerateColumns="False" 
            DataKeyNames="id"
            onrowdeleted="gridViewSpecializations_RowDeleted" 
            CssClass="gridView" 
            agerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" 
            onrowupdated="gridViewSpecializations_RowUpdated"
            onrowdatabound="gridViewSpecializations_RowDataBound">
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <Columns>
                <%--<asp:BoundField HeaderText="id" DataField="id" SortExpression="id" 
                InsertVisible="False" ReadOnly="True"  />--%>
                <asp:BoundField DataField="nazwa" HeaderText="nazwa" SortExpression="nazwa" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>
    <asp:LinqDataSource ID="ldsSpec" runat="server" OnSelecting="ldsSpec_Selecting"
        ContextTypeName="DAL.PrzychodniaDataClassesDataContext" TableName="Specjalizacjas"
        EnableDelete="True" EnableUpdate="True" OnDeleting="ldsSpec_Deleting" EntityTypeName="Specjalizacja"
        OnUpdating="ldsSpec_Updating">
    </asp:LinqDataSource>
</asp:Content>
