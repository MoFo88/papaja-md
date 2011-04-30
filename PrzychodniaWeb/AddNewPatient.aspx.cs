using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Drawing;

public partial class AddNewPatient : System.Web.UI.Page
{
    private String addMessage;
    public String AddMessage { get { return addMessage; } set { addMessage = value; lblAddMessage.Text = value; } }

    Uzytkownik user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            int id = Int32.Parse(Session["userId"].ToString());
            user = Repository.GetUserByID(id);   
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!Page.IsPostBack)
        {
            cbHasDr.Checked = false;
            ddlDrList.Enabled = false;
        }

        InitializeDdlDrList();
    }

    public void InitializeDdlDrList()
    {
        try
        {
            ddlDrList.DataSource = Repository.GetAllDoctors();
            ddlDrList.DataValueField = "id" ;
            ddlDrList.DataTextField = "Name";
            ddlDrList.DataBind();
        }
        catch(Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }
    protected void btnSubmitEdit_Click(object sender, EventArgs e)
    {
        try
        {

            decimal? pesel = null;

            try
            {
                pesel = Decimal.Parse( tbPesel.Text );
            }
            catch(Exception ex)
            {
                pesel = null;
            }

            int? idDr = null;

            if (cbHasDr.Checked)
            {
                try
                {
                    idDr = Int32.Parse( ddlDrList.SelectedValue );
                }
                catch(Exception ex)
                {
                    idDr = null;
                }
            }

            Repository.AddNewPatient(tbName.Text, tbSurname.Text, tbPostalCode.Text, tbCity.Text, tbStreetNr.Text, pesel, tbPesel.Text, tbStreet.Text, idDr);

            AddMessage = "Pacjent poprawnie dodany.";
            lblAddMessage.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            AddMessage = ex.Message;
            lblAddMessage.ForeColor = Color.Red;
        }
    }
    protected void cbHasDr_CheckedChanged(object sender, EventArgs e)
    {
        if (cbHasDr.Checked)
        {
            ddlDrList.Enabled = true;
        }
        else
        {
            ddlDrList.Enabled = false;
        }
    }
}