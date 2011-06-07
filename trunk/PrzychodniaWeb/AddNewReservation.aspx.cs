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

public partial class AddNewReservation : System.Web.UI.Page
{
    Uzytkownik user = null;
    Administrator admin = null;

    private DateTime[] reservationDates;
    private LinkButton[] reservationLinks;
    const string LOAD_CONTROLS = "LoadControls";

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
            InitializeDateTextBoxDefaultData();
            ViewState[VIEWSTATEKEY_DYNCONTROL] = "";
        }

        if (this.DynamicControlSelection == LOAD_CONTROLS)
        {
            InitializeDateTable();
        }
        //tbPesel.Text = "82345312345";//--------------------------------TESTS------------------------------------------
        InitializeDDL();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDateTime(tbFirstDayOfWeek.Text) == Repository.GetFirstDayOfWeek(System.DateTime.Now))
            {
                btnPrevWeek.Enabled = false;
            }
            else
            {
                btnPrevWeek.Enabled = true;
            }

            if (this.DynamicControlSelection == LOAD_CONTROLS)
            {
                InitializeDateTable();
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
            Lekarz lek = null;
            decimal pesel = Decimal.Parse(tbPesel.Text);

            Pacjent p = Repository.GetPatientByPesel(pesel);

            if (p == null)
            {
                lblNoDr.ForeColor = System.Drawing.Color.Red;
                lblNoDr.Text = "Nie istnieje pacjent o podanym numerze PESEL.";
                return;
            }

            ViewState["PacjentId"] = p.id;

            patientDataPanel.Visible = true;
            lblName.Text = p.imie;
            lblSurmane.Text = p.nazwisko;
            lblPesel.Text = p.pesel.ToString();
            lblPhone.Text = p.telefon;
            lblAdres.Text = "ul. " + p.ulica + " " + p.nr_domu + ", " + p.kod_pocztowy + " " + p.miasto;

            if (p.id_lek != null)
            {
                lek = Repository.GetUserByID((int)p.id_lek) as Lekarz;
                ViewState["LekarzId"] = lek.id;

                lblDrName.Text = lek.imie;
                lblDrSurname.Text = lek.nazwisko;
                InitializeTableHours(lek);
                patientDrDataPanel.Visible = true;
                panelDateChoose.Visible = true;
                InitializeDateTable();
            }
            else
            {
                lblNoDr.ForeColor = System.Drawing.Color.Red;
                lblNoDr.Text = "Wybrany użytkownik nie ma przypisanego lekarza.";
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void InitializeTableHours(Lekarz lek)
    {
        try
        {
            List<Godziny_przyj> hours = lek.Godziny_przyjs.ToList();

            lblDay1.Text = "";
            lblDay2.Text = "";
            lblDay3.Text = "";
            lblDay4.Text = "";
            lblDay5.Text = "";
            lblDay6.Text = "";
            lblDay7.Text = "";

            foreach (Godziny_przyj g in hours)
            {
                string _od = g.godz_od.ToString();
                string _do = g.godz_do.ToString();
                DateTime od_ = Convert.ToDateTime(_od);
                DateTime do_ = Convert.ToDateTime(_do);
                switch (g.dzien)
                {
                    case 1:
                        lblDay1.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + ", ";
                        break;
                    case 2:
                        lblDay2.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + ", ";
                        break;
                    case 3:
                        lblDay3.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + ", ";
                        break;
                    case 4:
                        lblDay4.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + ", ";
                        break;
                    case 5:
                        lblDay5.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + ", ";
                        break;
                    case 6:
                        lblDay6.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + ", ";
                        break;
                    case 7:
                        lblDay7.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString();
                        break;
                    default:
                        throw new BadDayIdentifyierException();
                }
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void InitializeDateTextBoxDefaultData()
    {
        try
        {
            DateTime today = System.DateTime.Now;
            DateTime firstDayOfWeek = Repository.GetFirstDayOfWeek(today);
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

            tbFirstDayOfWeek.Text = firstDayOfWeek.ToShortDateString();
            tbLastDayOfWeek.Text = lastDayOfWeek.ToShortDateString();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void InitializeDateTable()
    {
        Lekarz lek = null;
        if (ViewState["LekarzId"] != null)
        {
            int id = (int)ViewState["LekarzId"];
            lek = Repository.GetUserByID(id) as Lekarz;
        }
        else
        {
            lblNoDr.ForeColor = System.Drawing.Color.Red;
            lblNoDr.Text = "Wystąpił błąd. Nie wybrano lekarza.";
            return;
        }

        List<Godziny_przyj> godz = lek.Godziny_przyjs.ToList();
        List<string> hoursStrings_od = new List<string>();
        List<string> hoursStrings_do = new List<string>();

        DateTime earliest = DateTime.MaxValue;
        DateTime latest = DateTime.MinValue;
        foreach (Godziny_przyj h in godz)
        {
            hoursStrings_od.Add(h.godz_od.ToString());
            hoursStrings_do.Add(h.godz_do.ToString());
        }

        foreach (string s in hoursStrings_od)
        {
            if (Convert.ToDateTime(s) < earliest)
                earliest = Convert.ToDateTime(s);
        }

        foreach (string s in hoursStrings_do)
        {
            if (Convert.ToDateTime(s) > latest)
            {
                latest = Convert.ToDateTime(s);
            }
        }

        TimeSpan workHoursCount = latest - earliest;
        TimeSpan consultationLength = new TimeSpan(0, 30, 0);
        Table reservationTable = new Table();
        DateTime reservationHour = earliest;

        panelDatesTable.Controls.Clear();

        HtmlGenericControl h3 = new HtmlGenericControl("h3");
        h3.InnerText = "Lista terminów:";
        panelDatesTable.Controls.Add(h3);

        TableHeaderRow thrDays = new TableHeaderRow();
        string[] days = new string[]
        {
            "Poniedziałek",
            "Wtorek",
            "Środa",
            "Czwartek",
            "Piątek",
            "Sobota",
            "Niedziela"
        };

        thrDays.Cells.Add(new TableCell());
        foreach (string s in days)
        {
            TableHeaderCell thcDay = new TableHeaderCell();
            thcDay.Text = s;
            thrDays.Cells.Add(thcDay);
        }
        reservationTable.Rows.Add(thrDays);

        linksCount = (int)(workHoursCount.TotalMinutes / consultationLength.TotalMinutes) * days.Count();
        PrepareLinksArray();

        int index = 0;
        while (workHoursCount.CompareTo(TimeSpan.Zero) > 0)
        {
            TableRow tr = new TableRow();
            TableHeaderCell thc = new TableHeaderCell();

            thc.Text = reservationHour.ToShortTimeString();
            thc.HorizontalAlign = HorizontalAlign.Center;
            tr.Cells.Add(thc);
            for (int i = 0; i < days.Count(); i++)
            {
                TableCell tc = new TableCell();
                DateTime dt = Convert.ToDateTime(tbFirstDayOfWeek.Text + " " + reservationHour.ToShortTimeString());
                dt = dt.AddDays(i);
                reservationDates[index] = dt;
                tc.Controls.Add(reservationLinks[index]);
                index++;
                tc.HorizontalAlign = HorizontalAlign.Center;
                tr.Cells.Add(tc);
            }

            reservationTable.Rows.Add(tr);
            workHoursCount = workHoursCount.Subtract(consultationLength);
            reservationHour = reservationHour.Add(consultationLength);
        }
        ColorLinks();
        panelDatesTable.Controls.Add(reservationTable);
        panelDatesTable.Visible = true;
    }

    private void ColorLinks()
    {
        Lekarz lek = null;
        if (ViewState["LekarzId"] != null)
        {
            int id = (int)ViewState["LekarzId"];
            lek = Repository.GetUserByID(id) as Lekarz;
        }
        else
        {
            lblNoDr.ForeColor = System.Drawing.Color.Red;
            lblNoDr.Text = "Wystąpił błąd. Nie wybrano lekarza.";
            return;
        }

        int arrayLength = 7;
        int arrayHeight = linksCount / 7;

        for (int i = 0; i < arrayLength; i++)
        {
            int dayId = i + 1;
            List<Godziny_przyj> godz = lek.Godziny_przyjs.Where(g => g.dzien == dayId).ToList();
            if (godz.Count != 0)
            {
                foreach (Godziny_przyj g in godz)
                {
                    DateTime od_ = (DateTime)g.godz_od;
                    DateTime do_ = (DateTime)g.godz_do;

                    for (int j = i; j < linksCount; j = j + arrayLength)
                    {
                        int index = j;
                        if (reservationDates[index].TimeOfDay < od_.TimeOfDay ||
                            reservationDates[index].TimeOfDay > do_.TimeOfDay)
                        {
                            reservationLinks[index].ForeColor = Color.Gray;
                            reservationLinks[index].Attributes.Add("onclick", "javascript:if(confirm('W tym terminie wybrany lekarz nie przyjmuje. Czy na pewno chcesz kontynuować?')== false) return false;");
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < arrayHeight; j++)
                {
                    int index = j * arrayLength + i;
                    reservationLinks[index].ForeColor = Color.Gray;
                    reservationLinks[index].Attributes.Add("onclick", "javascript:if(confirm('W tym terminie wybrany lekarz nie przyjmuje. Czy na pewno chcesz kontynuować?')== false) return false;");
                }
            }
        }

        DateTime fdow = Convert.ToDateTime(tbFirstDayOfWeek.Text);
        DateTime ldow = Convert.ToDateTime(tbLastDayOfWeek.Text);

        List<Pacjent> patients = lek.Pacjents.ToList();
        foreach (Pacjent p in patients)
        {
            foreach (Rejestracja r in p.Rejestracjas.ToList())
            {
                if (r.data_od.Date > fdow.Date ||
                    r.data_do.Date < ldow.Date)
                {
                    for (int i = 0; i < linksCount; i++)
                    {
                        if (reservationDates[i] <= r.data_od &&
                            reservationDates[i].AddMinutes(30.0) >= r.data_do)
                        {
                            reservationLinks[i].ForeColor = Color.Red;
                            reservationLinks[i].Attributes.Add("onclick", "javascript:if(confirm('Wizyta w tym czasie jest już zarezerwowana. Czy na pewno chcesz kontynuować?')== false) return false;");
                        }
                    }
                }
            }
        }
    }



    private int ConvertDayOfWeek(DateTime dt)
    {
        switch (dt.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return 1;
            case DayOfWeek.Tuesday:
                return 2;
            case DayOfWeek.Wednesday:
                return 3;
            case DayOfWeek.Thursday:
                return 4;
            case DayOfWeek.Friday:
                return 5;
            case DayOfWeek.Saturday:
                return 6;
            case DayOfWeek.Sunday:
                return 7;
            default:
                throw new BadDayIdentifyierException();
        }
    }

    protected void PrepareLinksArray()
    {
        reservationLinks = new LinkButton[linksCount];
        reservationDates = new DateTime[linksCount];

        Lekarz lek = null;
        if (ViewState["LekarzId"] != null)
        {
            int id = (int)ViewState["LekarzId"];
            lek = Repository.GetUserByID(id) as Lekarz;
        }
        else
        {
            lblNoDr.ForeColor = System.Drawing.Color.Red;
            lblNoDr.Text = "Wystąpił błąd. Nie wybrano lekarza.";
            return;
        }

        for (int i = 0; i < linksCount; i++)
        {
            LinkButton lb = new LinkButton();
            lb.ID = "lbReservation_" + i.ToString();
            lb.Text = "Zapisz";
            lb.Visible = true;
            lb.Click += this.lbSignIn_Click;
            reservationLinks[i] = lb;
            panelDatesTable.Controls.Add(reservationLinks[i]);

        }
        this.DynamicControlSelection = LOAD_CONTROLS;
    }

    private int linksCount;

    protected void lbSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;
            string[] idSplit = lb.ID.Split('_');
            int index = Int32.Parse(idSplit.Last());

            panelReservationData.Visible = true;
            tbResDate.Text = reservationDates[index].ToShortDateString();
            tbResHourStart.Text = reservationDates[index].ToShortTimeString();
            tbResHourEnd.Text = reservationDates[index].AddMinutes(30.0).ToShortTimeString();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void btnPrevWeek_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime firstDayOfWeek = Convert.ToDateTime(tbFirstDayOfWeek.Text);
            DateTime lastDayOfWeek = Convert.ToDateTime(tbLastDayOfWeek.Text);

            firstDayOfWeek = firstDayOfWeek.AddDays(-7);
            lastDayOfWeek = lastDayOfWeek.AddDays(-7);

            tbFirstDayOfWeek.Text = firstDayOfWeek.ToShortDateString();
            tbLastDayOfWeek.Text = lastDayOfWeek.ToShortDateString();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void btnNextWeek_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime firstDayOfWeek = Convert.ToDateTime(tbFirstDayOfWeek.Text);
            DateTime lastDayOfWeek = Convert.ToDateTime(tbLastDayOfWeek.Text);

            firstDayOfWeek = firstDayOfWeek.AddDays(7);
            lastDayOfWeek = lastDayOfWeek.AddDays(7);

            tbFirstDayOfWeek.Text = firstDayOfWeek.ToShortDateString();
            tbLastDayOfWeek.Text = lastDayOfWeek.ToShortDateString();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void InitializeDDL()
    {
        try
        {
            List<Typ_rejestracja> resTypes = Repository.GetAllTyp_rejestracjas();
            ddlResType.DataSource = resTypes;
            ddlResType.DataValueField = "id";
            ddlResType.DataTextField = "nazwa";
            ddlResType.DataBind();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }
    protected void btnSubmitReservation_Click(object sender, EventArgs e)
    {
        DateTime dateBegin = new DateTime();
        DateTime dateEnd = new DateTime();
        int patientId;
        int reservationTypeId;

        try
        {
            dateBegin = Convert.ToDateTime(tbResDate.Text + " " + tbResHourStart.Text);
            dateEnd = Convert.ToDateTime(tbResDate.Text + " " + tbResHourEnd.Text);
            patientId = Int32.Parse(ViewState["PacjentId"].ToString());
            reservationTypeId = Int32.Parse(ddlResType.SelectedValue);

            bool res = Repository.AddNewReservation
            (
                patientId,
                dateBegin,
                dateEnd,
                reservationTypeId
            );

            tbResDate.Text = "";
            tbResHourStart.Text = "";
            tbResHourEnd.Text = "";

            if (res)
            {
                lblResult.ForeColor = Color.Green;
                lblResult.Text = "Rejestrację dodano poprawnie";
            }

            ColorLinks();
        }
        catch (FormatException ex)
        {
            lblResult.ForeColor = Color.Red;
            lblResult.Text = "Podano nieprawiłową datę lub czas.\n" + ex.Message;
        }
        catch (Exception ex)
        {
            lblResult.ForeColor = Color.Red;
            lblResult.Text = "Podczas dodawania rejestracji wystąpił błąd.\n" + ex.Message;
        }

    }
}