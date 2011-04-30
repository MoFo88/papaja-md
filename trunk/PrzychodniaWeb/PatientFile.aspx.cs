using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

public partial class PatientFile : System.Web.UI.Page
{

    private Uzytkownik user = null;
    private Lekarz dr = null;
    private Pacjent patient = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            user = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString()));

            if (user is Lekarz)
            {
                dr = user as Lekarz;

                if (Session["patientId"] != null)
                {
                    String patId = Session["patientId"].ToString();
                    user = Repository.GetUserByID(Int32.Parse(patId));

                    if (user is Pacjent)
                    {
                        patient = user as Pacjent;
                    }
                    else
                    {
                        Response.Redirect("~/NoPatient.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/NoPatient.aspx");
                }
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


    protected void Page_PreRender(object sender, EventArgs e)
    {
        lblPatientName.Text = patient.Name;
    }
    
}