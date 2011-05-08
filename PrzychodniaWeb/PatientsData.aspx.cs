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
        try
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
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Repository.GetAllPatients();
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
            Master.Message = e.Exception.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void LinqDataSource1_Updating(object sender, LinqDataSourceUpdateEventArgs e)
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
        catch (Exception ex)
        {
            Master.Message = e.Exception.Message;
            Master.SetMessageColor(Color.Red);
        }
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
        try
        {
            Pacjent  p = Repository.GetUserByID( Int32.Parse( e.Keys["id"].ToString() )) as Pacjent;

            GridView gv = (GridView)sender;
            GridViewRow gvr = gv.Rows[ gv.EditIndex ];


            //String imie = (e.NewValues["imie"] == null ) ? null : e.NewValues["imie"].ToString();
            //String nazwisko = (e.NewValues["nazwisko"] == null) ? null : e.NewValues["nazwisko"].ToString();
            //Decimal? pesel = Decimal.Parse( (e.NewValues["pesel"] == null) ? null : e.NewValues["pesel"].ToString() );
            //String kod_pocztowy = (e.NewValues["kod_pocztowy"] == null) ? null : e.NewValues["kod_pocztowy"].ToString() ;
            //String miasto = (e.NewValues["miasto"] == null) ? null : e.NewValues["miasto"].ToString() ;
            //String ulica = (e.NewValues["ulica"] == null) ? null : e.NewValues["ulica"].ToString(); 
            //String nr_domu = (e.NewValues["nr_domu"] == null) ? null : e.NewValues["nr_domu"].ToString() ;
            //String telefon = (e.NewValues["telefon"] == null) ? null : e.NewValues["telefon"].ToString() ;

            String s = (e.NewValues["id_lek"] ?? "").ToString();
            String ubezpieczenie = (e.NewValues["ubezpieczenie"] == null) ? null : e.NewValues["ubezpieczenie"].ToString();
            
            /*GridViewRow grv = gridViewPatients.Rows[ gridViewPatients.EditIndex ];
            DropDownList ddl = (DropDownList)gridViewPatients.Rows[gridViewPatients.EditIndex].FindControl("ddlEditDr");
            int? id_lek = Int32.Parse( ddl.SelectedValue );*/

            int? id_lek = null;
           
            id_lek = Int32.Parse((e.NewValues["id_lek"] == null) ? null : e.NewValues["id_lek"].ToString());

            if (id_lek == -1)
            {
                id_lek = null;
            }

            p.ubezpieczenie = ubezpieczenie;
            p.id_lek = id_lek;

            Repository.UpdatePacjentData(p);

            if (e.Exception != null)
            {
                Master.Message = e.Exception.Message;
                Master.SetMessageColor(Color.Red);
                e.ExceptionHandled = true;
            }

        }
        catch(Exception ex)
        {
            Master.Message = e.Exception.Message;
            Master.SetMessageColor(Color.Red);
        }
        
    }

    
    protected void gridViewPatients_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowState == DataControlRowState.Edit
            || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)))
            {

                int? id = ((Pacjent)e.Row.DataItem).id_lek;

                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlEditDr");
                String st = ddl.SelectedValue;

                ListItem li2 = ddl.Items.FindByValue(st);
                li2.Selected = false;

                if (id != null)
                {
                    ListItem li = ddl.Items.FindByValue(id.ToString());
                    li.Selected = true;
                }
                else
                {
                    ListItem li = ddl.Items.FindByValue("-1");
                    li.Selected = true;
                }
            }
        }
        catch(Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }

    }

    protected void gridViewPatients_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow grv = gridViewPatients.Rows[ gridViewPatients.EditIndex ];
            DropDownList ddl = (DropDownList)gridViewPatients.Rows[gridViewPatients.EditIndex].FindControl("ddlEditDr");
            e.NewValues["id_lek"] = ddl.SelectedValue;
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected String GetDrFullName(object o)
    {
        try
        {
            if (o != null)
            {
                int id_lek = Int32.Parse(Eval("id_lek").ToString());
                return Repository.GetUserByID(id_lek).Name;
            }

            return "-";
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
            return "-";
        }

        
    }
}  