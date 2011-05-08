<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientsData.aspx.cs" Inherits="PatientsData" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="DAL" %>

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
           <asp:BoundField DataField="ubezpieczenie" HeaderText="ubezpieczenie" 
                SortExpression="ubezpieczenie" />
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
            <asp:CommandField ShowDeleteButton="True" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>

    <PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>

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

