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
    private String message;

    public String Message { get { return message; } set { message = value; lblMessage.Text = value; } }

    public void SetMessageColor(Color color)
    {
        lblMessage.ForeColor = color;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Message = "";

            if (Session["userId"] != null)
            {
                int id = Int32.Parse(Session["userId"].ToString());
                user = Repository.GetUserByID(id);

                CreateMenu();
            }
        }
        catch (Exception ex)
        {
            Message = ex.Message;
            SetMessageColor(Color.Red);
        }
    }

    /// <summary>
    /// Tworzenie manu w zależności od teo, kto jest zalogowany
    /// </summary>
    protected void CreateMenu()
    {
        MenuItem miAddNewDoctor = new MenuItem();
        miAddNewDoctor.NavigateUrl = "~/AddNewDoctor.aspx";
        miAddNewDoctor.Text = "Dodaj Lekarza";

        MenuItem miAddNewPatient = new MenuItem();
        miAddNewPatient.NavigateUrl = "~/AddNewPatient.aspx";
        miAddNewPatient.Text = "Dodaj Pacjenta";


        if (user is Administrator)
        {
            NavigationMenu.Items.Add(miAddNewDoctor);
            NavigationMenu.Items.Add(miAddNewPatient);
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


    /// <summary>
    /// Funkkcja do dynamicznej zmiany stylu ()gdy nie da się CSS-em
    /// na razie nie wykorzystywana
    /// </summary>
    /// <param name="container"></param>
    /// <returns></returns>
    //public string GetItemStyle(MenuItemTemplateContainer container)
    //{
  
    //    MenuItem item = (MenuItem)container.DataItem;

    //    StateBag sbLeft = new StateBag();
    //    sbLeft.Add("float", "left");

    //    StateBag sbRight = new StateBag();
    //    sbRight.Add("float", "right");

    //    //identify based value
    //    if (item.Value != "-1")
    //    {
    //        Control c = (Control)item.DataItem;
    //    }

    //    return "";
    //}
}
