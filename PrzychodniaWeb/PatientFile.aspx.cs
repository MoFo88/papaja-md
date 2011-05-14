using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Drawing;

public partial class PatientFile : System.Web.UI.Page
{

    private Uzytkownik user = null;
    private Lekarz dr = null;
    private Pacjent patient = null;

    private string kJError;
    public string KJError { get { return kJError; } set { lblKJError.Text = value; kJError = value; lblKJError.ForeColor = Color.Red; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
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

            if (!Page.IsPostBack)
            {
                lblEnsurance.Text = patient.ubezpieczenie;
                if (patient.ostatnia_wizyta != null ) lblLastVisite.Text = patient.ostatnia_wizyta.ToString().Substring(0, 10);
                lblPatientName.Text = patient.Name;
                lblPesel.Text = patient.pesel.ToString();
                lblPhone.Text = patient.telefon;
                KJError = "";
            }

            


        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected override void  Render(HtmlTextWriter writer)
    {

        int max1 = Repository.GegMaxKJid();
        int max2 = Repository.GegMaxKJGid();
        int max3 = Repository.GegMaxKJPGid();

        for (int i = 0; i <= max1 + 1; i++)
        {
            ClientScript.RegisterForEventValidation(ddlKJ.UniqueID, i.ToString());
        }

        for (int i = 0; i < max2 + 1; i++)
        {
            ClientScript.RegisterForEventValidation(ddlKJg.UniqueID, i.ToString());
        }

        for (int i = 0; i < max3 + 1; i++)
        {
            ClientScript.RegisterForEventValidation(ddlKJpg.UniqueID, i.ToString());
        }  

        Page.ClientScript.RegisterForEventValidation(btnSubmit.UniqueID, this.ToString());
        base.Render(writer);
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            int patientId = Int32.Parse(Session["patientId"].ToString());

            String r = tbRecepty.Text;
            String s = tbSkierowania.Text;
            String z = tbZalecenia.Text;
            String w = tbWywiadBadania.Text;
            int kjId = 0;

            try
            {
               kjId  = Int32.Parse(ddlKJ.SelectedValue);
            }
            catch (Exception ex)
            {
                KJError = "Wybierz kod jednostki.";
            }
            KJError = "";


            Repository.AddNewField(patientId, kjId , w, r, s, z); 
            
        }
        catch (Exception ex)
        {
            KJError = ex.Message;
        }
    }
}