using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class CancelReservation : System.Web.UI.Page
{
    const string LOAD_CONTROLS = "LoadControls";
    Uzytkownik user = null;
    Administrator admin = null;
    const string VIEWSTATEKEY_DYNCONTROL = "DynamicControlSelection";
    //przechwuje wartość własciwosci we ViewState pomiedzy PostBackami
    private string DynamicControlSelection
    {
        get
        {
            string result = (string)ViewState[VIEWSTATEKEY_DYNCONTROL];
            if (result == null)
            {
                //zapobieganie zwracaniu nulli przez wlasnosc
                return string.Empty;
            }
            else
            {
                return result;
            }
        }
        set
        {
            ViewState[VIEWSTATEKEY_DYNCONTROL] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userId"] != null)
        {
            user = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString()));

            if (user is Administrator)
            {
                admin = user as Administrator;
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
            ViewState[VIEWSTATEKEY_DYNCONTROL] = "";
        }

        if (this.DynamicControlSelection == LOAD_CONTROLS)
        {
            InitializeReservationsInfo();
        }
        //tbPesel.Text = "82345312345";//--------------------------------TESTS------------------------------------------

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (this.DynamicControlSelection == LOAD_CONTROLS)
            {
                InitializeReservationsInfo();
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void btnSearchPatient_Click(object sender, EventArgs e)
    {
        try
        {
            decimal pesel = Decimal.Parse(tbPesel.Text);

            Pacjent p = Repository.GetPatientByPesel(pesel);

            if (p == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Nie istnieje pacjent o podanym numerze PESEL.";
                return;
            }

            ViewState["PacjentId"] = p.id;
            Lekarz lek = null;

            if (p.id_lek != null)
            {
                lek = Repository.GetUserByID((int)p.id_lek) as Lekarz;
                lblDrName.Text = lek.Name;
            }
            else
            {
                lblDrName.Text = "brak";
            }

            patientDataPanel.Visible = true;
            lblName.Text = p.imie;
            lblSurmane.Text = p.nazwisko;
            lblPhone.Text = p.telefon;
            lblAdres.Text = "ul. " + p.ulica + " " + p.nr_domu + ", " + p.kod_pocztowy + " " + p.miasto;
            InitializeReservationsInfo();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    private void InitializeReservationsInfo()
    {
        if(ViewState["PacjentId"] == null)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Nie istnieje pacjent o podanym numerze PESEL.";
                return;
        }
        int patientId = Int32.Parse(ViewState["PacjentId"].ToString());
        List<Rejestracja> rejList = Repository.GetAllPatientReservations(patientId);

        patientsReservationsPanel.Controls.Clear();

        foreach (Rejestracja r in rejList)
        {
            if (r.data_od >= DateTime.Now)
            {
                HtmlGenericControl fieldSet = new HtmlGenericControl("fieldset");
                HtmlGenericControl legend = new HtmlGenericControl("legend");
                Label lbl1 = new Label();
                Label lbl2 = new Label();
                Label lbl3 = new Label();
                Button btn = new Button();
                string typ = Repository.GetTypRejestracjaById(r.id_typ).nazwa;

                legend.InnerText = "Wizyta: " + r.data_od.ToShortDateString();
                fieldSet.Controls.Add(legend);
                lbl1.Text = "Godziny wizyty:";
                fieldSet.Controls.Add(lbl1);
                fieldSet.Controls.Add(new LiteralControl("<br/>"));
                lbl2.Text = r.data_od.ToShortTimeString() + " - " + r.data_do.ToShortTimeString();
                fieldSet.Controls.Add(lbl2);
                fieldSet.Controls.Add(new LiteralControl("<br/>"));
                lbl3.Text = "Typ rejestracji: " + typ;
                fieldSet.Controls.Add(lbl3);
                fieldSet.Controls.Add(new LiteralControl("<br/>"));
                btn.ID = "btnDelete_" + r.id;
                btn.Click += this.btnDelete_Click;
                btn.Attributes.Add("onclick", "javascript:if(confirm('Czy na pewno chcesz usunąć wybraną rejestrację?')== false) return false;");
                btn.Text = "Usuń";
                fieldSet.Controls.Add(btn);
                patientsReservationsPanel.Controls.Add(fieldSet);
            }
        }
        patientsReservationsPanel.Visible = true;
        this.DynamicControlSelection = LOAD_CONTROLS;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            string[] idSplit = btn.ID.Split('_');
            int resId = Int32.Parse(idSplit.Last());

            Repository.DeleteReservation(resId);
            Master.Message = "Poprawnie usunięto rejestrację";
            Master.SetMessageColor(Color.Green);
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }
}