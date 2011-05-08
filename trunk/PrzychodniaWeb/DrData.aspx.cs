using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Drawing;

public partial class DrData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
    }

    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Repository.GetAllDoctors();
    }

    protected void LinqDataSource1_Deleting(object sender, LinqDataSourceDeleteEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }
    protected void gridViewDrs_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        try
        {
            if (e.Exception != null)
            {
                Master.Message = e.Exception.Message;
                Master.SetMessageColor(Color.Red);
                e.ExceptionHandled = true;
            }
        }
        catch(Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }
    protected void gridViewDrs_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        try
        {
            Lekarz p = Repository.GetUserByID(Int32.Parse(e.Keys["id"].ToString())) as Lekarz;

            GridView gv = (GridView)sender;
            GridViewRow gvr = gv.Rows[gv.EditIndex];

            String email = (e.NewValues["email"] == null) ? null : e.NewValues["email"].ToString();

            p.email = email; 

            Repository.UpdateDrData(p);

            if (e.Exception != null)
            {
                Master.Message = e.Exception.Message;
                Master.SetMessageColor(Color.Red);
                e.ExceptionHandled = true;
            }

        }
        catch (Exception ex)
        {
            Master.Message = e.Exception.Message;
            Master.SetMessageColor(Color.Red);
        }
    }
}