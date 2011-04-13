using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginControl_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Login log = (Login)HeadLoginView.FindControl("LoginControl");
        Uzytkownik u = Repository.UserAuth(log.UserName, log.Password);
        
        if (u != null)
        {
            e.Authenticated = true;
            Session["userId"] = u.id;
            Session["type"] = u.id_typ;
        }
    }
}
