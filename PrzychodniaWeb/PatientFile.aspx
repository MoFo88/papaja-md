<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientFile.aspx.cs" Inherits="PatientFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Kartoteka pacjenta</title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {

        
            $('.tbResize').autoResize({
                // On resize:
                onResize: function () {
                    $(this).css({ opacity: 0.6 });
                },
                // After resize:
                animateCallback: function () {
                    $(this).css({ opacity: 1 });
                },
                // Quite slow animation:
                animateDuration: 300,
                // More extra space:
                extraSpace: 20
            });
        });


    </script>

    <script type="text/javascript">

        (function ($) {

            $.fn.autoResize = function (options) {

                var settings = $.extend({
                    onResize: function () { },
                    animate: true,
                    animateDuration: 150,
                    animateCallback: function () { },
                    extraSpace: 10,
                    limit: 1000
                }, options);

           
                this.filter('textarea').each(function () {

                
                    var textarea = $(this).css({ resize: 'none', 'overflow-y': 'hidden' }),

                
                    origHeight = textarea.height(),

                
                    clone = (function () {

                    
                        var props = ['height', 'width', 'lineHeight', 'textDecoration', 'letterSpacing'],
                            propOb = {};

                    
                        $.each(props, function (i, prop) {
                            propOb[prop] = textarea.css(prop);
                        });

                    
                        return textarea.clone().removeAttr('id').removeAttr('name').css({
                            position: 'absolute',
                            top: 0,
                            left: -9999
                        }).css(propOb).attr('tabIndex', '-1').insertBefore(textarea);

                    })(),
                    lastScrollTop = null,
                    updateSize = function () {

                    
                        clone.height(0).val($(this).val()).scrollTop(10000);

                   
                        var scrollTop = Math.max(clone.scrollTop(), origHeight) + settings.extraSpace,
                            toChange = $(this).add(clone);

                   
                        if (lastScrollTop === scrollTop) { return; }
                        lastScrollTop = scrollTop;

                   
                        if (scrollTop >= settings.limit) {
                            $(this).css('overflow-y', '');
                            return;
                        }
                    
                        settings.onResize.call(this);

                    
                        settings.animate && textarea.css('display') === 'block' ?
                            toChange.stop().animate({ height: scrollTop }, settings.animateDuration, settings.animateCallback)
                            : toChange.height(scrollTop);
                    };

                
                    textarea
                    .unbind('.dynSiz')
                    .bind('keyup.dynSiz', updateSize)
                    .bind('keydown.dynSiz', updateSize)
                    .bind('change.dynSiz', updateSize);

                });

           
                return this;

            };



        })(jQuery);

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="name">
        <h1><asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label></h1>
    </div>


    <p><asp:Label ID="lblPesel_" runat="server" Text="Pesel: "></asp:Label><asp:Label id="lblPesel" runat="server"></asp:Label></p>
    <p><asp:Label ID="lblEnsurance_" runat="server" Text="Ubezpieczenie: "></asp:Label><asp:Label id="lblEnsurance" runat="server"></asp:Label></p>
    <p><asp:Label ID="lblPhone_" runat="server" Text="Telefon: "></asp:Label><asp:Label id="lblPhone" runat="server"></asp:Label></p>
    <p><asp:Label ID="lblLastVisite_" runat="server" Text="Ostatnia wizyta: "></asp:Label><asp:Label id="lblLastVisite" runat="server"></asp:Label></p>
        
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    
    <asp:Panel ID="panelField" runat="server" CssClass="panelField">
        
        <asp:TabContainer ID="tabConteinerField" runat="server" >
            
            <asp:TabPanel 
                ID="tabWywiadBadania" 
                runat="server"
                TabIndex="1"
                HeaderText="Wywiad/Badania"
                >

                <ContentTemplate>
                
                    <asp:TextBox ID="tbWywiadBadania" runat="server" CssClass="tbResize" TextMode="MultiLine">
                    </asp:TextBox>

                </ContentTemplate>

            </asp:TabPanel>

            <asp:TabPanel 
                ID="tabRecepty" 
                runat="server"
                TabIndex="2"
                HeaderText="Recepty" 
                >

                <ContentTemplate>
                
                    <asp:TextBox ID="tbRecepty" runat="server" CssClass="tbResize" TextMode="MultiLine">
                    </asp:TextBox>

                </ContentTemplate>
                
            </asp:TabPanel>

            <asp:TabPanel
                Id="tabSkierowania"
                runat="server"
                TabIndex="3"
                HeaderText="Skierowania"
                >

                <ContentTemplate>
                
                    <asp:TextBox ID="tbSkierowania" runat="server" CssClass="tbResize" TextMode="MultiLine">
                    </asp:TextBox>

                </ContentTemplate>
                
            </asp:TabPanel>

            <asp:TabPanel
                Id="tabZalecenia"
                runat="server"
                TabIndex="4"
                HeaderText="Zalecenia"
                >

                <ContentTemplate>
                
                    <asp:TextBox ID="tbZalecenia" runat="server" CssClass="tbResize" TextMode="MultiLine">
                    </asp:TextBox>

                </ContentTemplate>
                
            </asp:TabPanel>

        </asp:TabContainer>

        <%--
        
        
        
        end tab container
        
        
        
        --%>
        
        <asp:CascadingDropDown
            ID="CascadingDropDown1"
            runat="server"
            TargetControlID="ddlKJg" 
            Category="KJG" 
            PromptText="Wybierz kod jednostki:" 
            ServicePath="~/JKWebService.asmx"
            ServiceMethod="GetKjgContent"
         
        />

        <asp:CascadingDropDown
            ID="CascadingDropDown2"
            runat="server"
            TargetControlID="ddlKJpg" 
            ParentControlID="ddlKJg"
            Category="KJPG" 
            PromptText="Wybierz kod jednostki:" 
            ServicePath="~/JKWebService.asmx"
            ServiceMethod="GetKjpgContent"
       
        />

        <asp:CascadingDropDown
            ID="CascadingDropDown3"
            runat="server"
            TargetControlID="ddlKJ" 
            ParentControlID="ddlKJpg"
            Category="KJ" 
            PromptText="Wybierz kod jednostki:" 
            ServicePath="~/JKWebService.asmx"
            ServiceMethod="GetKjContent"

        />

        <p>           
            <asp:Label ID="lblKJ" runat="server" Text="Kod jednostki ICD-10: "></asp:Label><br />
            <asp:DropDownList ID="ddlKJg" runat="server"></asp:DropDownList><br />
            <asp:DropDownList   ID="ddlKJpg" runat="server"></asp:DropDownList><br />
            <asp:DropDownList   ID="ddlKJ" runat="server"></asp:DropDownList><br />    
            <asp:Label ID="lblKJError" runat="server" Text=""></asp:Label><br />
        </p>

        <p class="submitButton" >          
            <asp:Button ID="btnSubmit" runat="server" Text="Ok" onclick="btnSubmit_Click" CssClass="button"  />
        </p>
        <asp:GridView   ID="GridViewPatientFields" 
                        runat="server" 
                        AllowPaging="True" 
                        AutoGenerateColumns="False" 
                        DataSourceID="ObjectDataSourcePatirntField"
                        CssClass="gridView"
                        DataKeyNames="id"
                        HeaderStyle-CssClass="header"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        >
            <Columns>
                <asp:TemplateField HeaderText="Kartoteka" SortExpression="data">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data") %>'></asp:TextBox><br /><br />
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("wywiad_badania") %>'></asp:TextBox><br />
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("recetpy") %>'></asp:TextBox><br />
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("skierowania") %>'></asp:TextBox><br />
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("zalecenie") %>'></asp:TextBox><br />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("data") %>'></asp:Label><br /><br />
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("wywiad_badania") %>'></asp:Label><br />
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("recetpy") %>'></asp:Label><br />
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("skierowania") %>'></asp:Label><br />
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("zalecenie") %>'></asp:Label><br />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>


        <asp:ObjectDataSource  
            ID="ObjectDataSourcePatirntField" 
            runat="server" 
            SelectMethod="GetAllPatientFields" 
            TypeName="BLL.Repository"
            
            >
            <SelectParameters>
                <asp:SessionParameter  SessionField="patientId" Type="Int32" DefaultValue="-1" 
                    Name="idPatient" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </asp:Panel>

</asp:Content>

