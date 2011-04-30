using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Drawing;

public partial class MyPatients : System.Web.UI.Page
{

    private Uzytkownik user = null;
    private Lekarz dr = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userId"] != null)
            {
                user = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString()));

                if (user is Lekarz)
                {
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void gridViewMyPatients_SelectedIndexChanged(object sender, EventArgs e)
    {
        String value = gridViewMyPatients.SelectedValue.ToString();
        Session["patientId"] = value;
        Response.Redirect("~/PatientFile.aspx");
    }

    protected void LinqDataSourceMyPatients_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Repository.GetAllDrPatients(Int32.Parse(Session["userId"].ToString()));
    }
}