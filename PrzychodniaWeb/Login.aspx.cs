using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            Uzytkownik u = Repository.UserAuth(LoginUser.UserName, LoginUser.Password);
            Session["userId"] = u.id;
            Session["type"] = u.id_typ;
            
            e.Authenticated = true;
        }
        catch (NoUserException ex)
        {
        }
    }
}
