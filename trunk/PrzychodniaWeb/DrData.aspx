<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DrData.aspx.cs" Inherits="DrData" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

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
        onrowdeleted="gridViewDrs_RowDeleted" onrowupdated="gridViewDrs_RowUpdated"
        >
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
            <asp:BoundField DataField="imie" HeaderText="imie" SortExpression="imie" />
            <asp:BoundField DataField="nazwisko" HeaderText="nazwisko" 
                SortExpression="nazwisko" />
            <asp:BoundField DataField="pesel" HeaderText="pesel" SortExpression="pesel" />
            <asp:BoundField DataField="kod_pocztowy" HeaderText="kod_pocztowy" 
                SortExpression="kod_pocztowy" />
            <asp:BoundField DataField="miasto" HeaderText="miasto" 
                SortExpression="miasto" />
            <asp:BoundField DataField="ulica" HeaderText="ulica" SortExpression="ulica" />
            <asp:BoundField DataField="nr_domu" HeaderText="nr_domu" 
                SortExpression="nr_domu" />
            <asp:BoundField DataField="telefon" HeaderText="telefon" 
                SortExpression="telefon" />
            <asp:BoundField DataField="email" HeaderText="email" 
                SortExpression="email" />
            
            <asp:CommandField ShowDeleteButton="True" />
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowEditButton="True" />
            
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>

    <asp:LinqDataSource 
        ID="LinqDataSource1" 
        runat="server"
        TableName="Uzytkowniks"
        EntityTypeName="Lekarz" 
        onselecting="LinqDataSource1_Selecting" 
        ContextTypeName="DAL.PrzychodniaDataClassesDataContext" 
        EnableDelete="True" EnableUpdate="True" ondeleting="LinqDataSource1_Deleting"
        >
    </asp:LinqDataSource>

</asp:Content>

