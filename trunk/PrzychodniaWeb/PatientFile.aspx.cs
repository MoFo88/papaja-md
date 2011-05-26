using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Drawing;
using System.Runtime.Serialization;
using System.Xml;

public partial class PatientFile : System.Web.UI.Page
{

    private Uzytkownik user = null;
    private Lekarz dr = null;
    private Pacjent patient = null;

    private string kJError;
    public string KJError { get { return kJError; } set { lblKJError.Text = value; kJError = value; lblKJError.ForeColor = Color.Red; } }

    private string kJErrorEdit;
    public string KJErrorEdit { get { return kJErrorEdit; } set { lblKJError2.Text = value; kJErrorEdit = value; lblKJError2.ForeColor = Color.Red; } }


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
                lblKJError.Text = "";
                lblSucces.Text = "";
                Master.Message = "";
                lblEditDeleteMessage.Text = "";


                lblEnsurance.Text = patient.ubezpieczenie;
                if (patient.ostatnia_wizyta != null) lblLastVisite.Text = patient.ostatnia_wizyta.ToString().Substring(0, 10);
                lblPatientName.Text = patient.Name;
                lblPesel.Text = patient.pesel.ToString();
                lblPhone.Text = patient.telefon;
                KJError = "";
                ViewState["kjId"] = null;

                GridViewPatientFields.Attributes.Add("rowdeleting", "javascript:if(confirm('Czy na pewno chcesz usunąć tego użytkownika?')== false) return false;");
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
            
            lblSucces.Text = "Wpis do kartoteki poprawnie dodany.";
            lblSucces.ForeColor = Color.Green;

            GridViewPatientFields.DataBind();
        }
        catch (Exception ex)
        {
            KJError = ex.Message;
        }
    }

    //for gridViec
    protected String GetKJ( object idKj )
    {
        try
        {
            int idKodJednostki = (int)idKj;

            return Repository.GetKJById(idKodJednostki).Name;
        }
        catch (Exception ex)
        {
            return  ex.Message;
        }
    }

   


    protected void GridViewPatientFields_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if (ViewState["kjId"] == null || ViewState["kjId"].ToString() == "" || !char.IsDigit(ViewState["kjId"].ToString()[0]))
            {
                e.Cancel = true;
                throw new NoKJException();
            }
        }
        catch(NoKJException ex)
        {
            KJErrorEdit = ex.Message;
            
        }
        catch(Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void ObjectDataSourcePatirntField_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        try
        {
            Wpis_kartoteka wk = (Wpis_kartoteka)(e.InputParameters["wk"]);

            if (ViewState["kjId"] == null || ViewState["kjId"].ToString() ==  "" || !char.IsDigit(ViewState["kjId"].ToString()[0]))
            {
                e.Cancel = true;
                throw new NoKJException();
            }
            else
            {
                int kjId = Int32.Parse(ViewState["kjId"].ToString());
                wk.id_kod_jedn = kjId;
            }
        }
        catch (NoKJException ex)
        {
            KJErrorEdit = ex.Message;
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void GridViewPatientFields_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        try
        {

            ViewState["kjId"] = null;
            lblEditDeleteMessage.Text = "Kartoteka została uaktualniona." ;
            lblEditDeleteMessage.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            lblEditDeleteMessage.Text = ex.Message;
            lblEditDeleteMessage.ForeColor = Color.Red;
        }
    }


    protected void ddlKJ2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["kjId"] = ddlKJ2.SelectedValue.ToString();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor( Color.Red );
        }
    }

    protected void ObjectDataSourcePatientField_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        try
        {
            lblEditDeleteMessage.Text = "Wpis kartoterki został usunięty.";
            lblEditDeleteMessage.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            lblEditDeleteMessage.Text = ex.Message;
            lblEditDeleteMessage.ForeColor = Color.Red;
        }
    }


    protected void GridViewPatientFields_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;
                        if (button != null && button.CommandName == "Delete")

                            button.OnClientClick = 
                                    "if (!confirm('Jesteś pewien że chcesz usunąć ten wpis?')) return;";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblEditDeleteMessage.Text = ex.Message;
            lblEditDeleteMessage.ForeColor = Color.Red;
        }
    }
}