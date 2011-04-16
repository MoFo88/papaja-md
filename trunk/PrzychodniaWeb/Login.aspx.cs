using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

        //TextBox tbUserName = (TextBox)LoginUser.FindControl("UserName");
        //TextBox tbPassword = (TextBox)LoginUser.FindControl("Password");

        try
        {
            Uzytkownik u = Repository.UserAuth(LoginUser.UserName, LoginUser.Password);
            Session["userId"] = u.id;
            Session["type"] = u.id_typ;         
            Page.Response.Redirect("~/Default.aspx");
            


        }
        catch(NoUserException ex)
        {
        }
    }
}
