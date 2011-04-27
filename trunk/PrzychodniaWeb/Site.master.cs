using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Drawing;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    private Uzytkownik user = null;
    private Pacjent patient = null;
    private Administrator admin = null;
    private Lekarz dr = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            int id = Int32.Parse(Session["userId"].ToString() );
            user = Repository.GetUserByID(id);

            CreateMenu();
        }   
    }

    protected void CreateMenu()
    {
        MenuItem miAddNewDoctor = new MenuItem();
        miAddNewDoctor.NavigateUrl = "~/AddNewDoctor.aspx";
        miAddNewDoctor.Text = "Dodaj Lekarza";


        if (user is Administrator)
        {
            NavigationMenu.Items.Add(miAddNewDoctor);
        }

        MenuItem miMyAccount = new MenuItem();
        miMyAccount.NavigateUrl = "~/MyAccount.aspx";
        miMyAccount.Text = "Moje konto";
        miMyAccount.Value = "-1";

        NavigationMenu.Items.Add(miMyAccount);

    }

    protected void LoginControl_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Login log = (Login)HeadLoginView.FindControl("LoginControl");

        try
        {
            Uzytkownik u = Repository.UserAuth(log.UserName, log.Password);

            e.Authenticated = true;
            Session["userId"] = u.id;
            Session["type"] = u.id_typ;
        }
        catch (NoUserException ex)
        {

        }

    }
    protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Session.Abandon();
    }


    public string GetItemStyle(MenuItemTemplateContainer container)
    {
        
        
        MenuItem item = (MenuItem)container.DataItem;

        StateBag sbLeft = new StateBag();
        sbLeft.Add("flat", "left");

        StateBag sbRight = new StateBag();
        sbRight.Add("flat", "right");

        //identify based value
        if (item.Value != "-1")
        {
            Control c = (Control)item.DataItem;
        }

        return "";
    }
}
