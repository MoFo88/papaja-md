using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Drawing;

public partial class PatientsData : System.Web.UI.Page
{
    private Uzytkownik user = null;
    private Administrator admin = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    if (Session["userId"] != null)
        //    {
        //        user = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString()));

        //        if (user is Administrator)
        //        {
        //            admin = user as Administrator;
        //        }
        //        else
        //        {
        //            Response.Redirect("~/Login.aspx");
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("~/Login.aspx");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Master.Message = ex.Message;
        //    Master.SetMessageColor(Color.Red);
        //}
    }

    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Repository.GetAllPatients();
    }

    protected void gridViewPatients_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void LinqDataSource1_Deleting(object sender, LinqDataSourceDeleteEventArgs e)
    {
        if (e.Exception != null)
        {
            Master.Message = e.Exception.Message;
            Master.SetMessageColor(Color.Red);
            e.ExceptionHandled = true;
        }

        int id = ((Uzytkownik)e.OriginalObject).id;
        Repository.DeleteUser(id);

    }
    protected void gridViewPatients_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            Master.Message = e.Exception.Message;
            Master.SetMessageColor(Color.Red);
            e.ExceptionHandled = true;
        }
    }
    protected void gridViewPatients_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            Master.Message = e.Exception.Message;
            Master.SetMessageColor(Color.Red);
            e.ExceptionHandled = true;
        }
    }
    protected void LinqDataSource1_Updating(object sender, LinqDataSourceUpdateEventArgs e)
    {
        if (e.Exception != null)
        {
            Master.Message = e.Exception.Message;
            Master.SetMessageColor(Color.Red);
            e.ExceptionHandled = true;
        }
    }
}  