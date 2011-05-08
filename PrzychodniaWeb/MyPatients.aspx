<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyPatients.aspx.cs" Inherits="MyPatients" %>
<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:GridView 
        ID="gridViewMyPatients" 
        runat="server" 
        AutoGenerateColumns="False" 
        DataSourceID="LinqDataSourceMyPatients" 
        onselectedindexchanged="gridViewMyPatients_SelectedIndexChanged"
        AllowSorting="True"
        AllowPaging="True" 
        DataKeyNames="id"
        GridLines="None"  
        CssClass="gridView"  
        PagerStyle-CssClass="pgr"  
        AlternatingRowStyle-CssClass="alt"
        >
        <Columns>
            
            <asp:BoundField DataField="imie" HeaderText="imie" SortExpression="imie" />
            <asp:BoundField DataField="nazwisko" HeaderText="nazwisko" SortExpression="nazwisko" />
            <asp:BoundField DataField="pesel" HeaderText="pesel" SortExpression="pesel" />
            <asp:BoundField DataField="ostatnia_wizyta" HeaderText="ostatnia_wizyta" SortExpression="ostatnia_wizyta" />
            <asp:CommandField ItemStyle-CssClass="selectImage" SelectImageUrl="~/images/arrowRight.png" ButtonType="Image" HeaderText="Zobacz"  ShowSelectButton="True" />
        
        </Columns>
    </asp:GridView>

    <asp:LinqDataSource 
        ID="LinqDataSourceMyPatients" 
        runat="server" ContextTypeName="DAL.PrzychodniaDataClassesDataContext" 
        TableName="Uzytkowniks" onselecting="LinqDataSourceMyPatients_Selecting"        
        >

    </asp:LinqDataSource>

</asp:Content>

