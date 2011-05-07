<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientsData.aspx.cs" Inherits="PatientsData" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:GridView 
        ID="gridViewPatients" 
        runat="server" 
        DataSourceID="LinqDataSource1" 
        AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False" 
        onselectedindexchanged="gridViewPatients_SelectedIndexChanged" 
        DataKeyNames="id" 
        onrowdeleted="gridViewPatients_RowDeleted"
        CssClass="gridView"  
        PagerStyle-CssClass="pgr"  
        AlternatingRowStyle-CssClass="alt" onrowupdated="gridViewPatients_RowUpdated"
        >
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField HeaderText="id" DataField="id" SortExpression="id" 
                InsertVisible="False" ReadOnly="True"  />
            <asp:BoundField HeaderText="imie" DataField="imie" SortExpression="imie"  />
            <asp:BoundField HeaderText="nazwisko" DataField="nazwisko" 
                SortExpression="nazwisko"  />
            <asp:BoundField HeaderText="pesel" DataField="pesel" SortExpression="pesel"  />
            <asp:BoundField HeaderText="kod_pocztowy" DataField="kod_pocztowy" 
                SortExpression="kod_pocztowy"  />
            <asp:BoundField HeaderText="miasto" DataField="miasto" 
                SortExpression="miasto"  />
            <asp:BoundField DataField="ulica" HeaderText="ulica" SortExpression="ulica" />
            <asp:BoundField DataField="nr_domu" HeaderText="nr_domu" 
                SortExpression="nr_domu" />
            <asp:BoundField DataField="telefon" HeaderText="telefon" 
                SortExpression="telefon" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>

    <asp:LinqDataSource 
        ID="LinqDataSource1"  
        runat="server" 
        onselecting="LinqDataSource1_Selecting"
        AutoSort = "true"
        ContextTypeName="DAL.PrzychodniaDataClassesDataContext" 
        EnableDelete="true"
        TableName="Uzytkowniks" 
        ondeleting="LinqDataSource1_Deleting" 
        EnableUpdate="True" onupdating="LinqDataSource1_Updating"
        
        >
    </asp:LinqDataSource>

</asp:Content>

