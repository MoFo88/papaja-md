using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Drawing;
using System.Web.UI.HtmlControls;

public partial class DrReservations : System.Web.UI.Page
{
    private int reservationsCount;
    private DateTime[] reservationDates;
    private Label[] reservationLabels;
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
        if (!Page.IsPostBack)
        {
            InitializeDDL();
            InitializeDateTextBoxDefaultData();
            ViewState[VIEWSTATEKEY_DYNCONTROL] = "";
        }
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

    protected void InitializeDDL()
    {
        try
        {
            List<Lekarz> drList = Repository.GetAllDoctors();

            ddlDrList.DataSource = drList;
            ddlDrList.DataValueField = "id";
            ddlDrList.DataTextField = "Name";
            ddlDrList.DataBind();

            ListItem itm = new ListItem();
            itm.Text = "Wybierz lekarza";
            itm.Value = "-1";

            ddlDrList.Items.Insert(0, itm);
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
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

        reservationsCount = (int)(workHoursCount.TotalMinutes / consultationLength.TotalMinutes) * days.Count();
        PrepareLabelsArray();

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
                tc.Controls.Add(reservationLabels[index]);
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
        int arrayHeight = reservationsCount / 7;

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

                    for (int j = i; j < reservationsCount; j = j + arrayLength)
                    {
                        int index = j;
                        if (reservationDates[index].TimeOfDay < od_.TimeOfDay ||
                            reservationDates[index].TimeOfDay > do_.TimeOfDay)
                        {
                            reservationLabels[index].ForeColor = Color.Gray;
                            reservationLabels[index].Text = "Nie przyjmuje";
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < arrayHeight; j++)
                {
                    int index = j * arrayLength + i;
                    reservationLabels[index].ForeColor = Color.Gray;
                    reservationLabels[index].Text = "Nie przyjmuje";
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
                    for (int i = 0; i < reservationsCount; i++)
                    {
                        if (reservationDates[i] <= r.data_od &&
                            reservationDates[i].AddMinutes(30.0) >= r.data_do)
                        {
                            reservationLabels[i].ForeColor = Color.Red;
                            reservationLabels[i].Text = "Zarezerwowany";
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

    protected void PrepareLabelsArray()
    {
        reservationLabels = new Label[reservationsCount];
        reservationDates = new DateTime[reservationsCount];

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

        for (int i = 0; i < reservationsCount; i++)
        {
            Label lbl = new Label();
            lbl.ID = "lblReservation_" + i.ToString();
            lbl.Text = "Wolny";
            lbl.ForeColor = Color.Green;
            lbl.Visible = true;
            reservationLabels[i] = lbl;
            panelDatesTable.Controls.Add(reservationLabels[i]);

        }
        this.DynamicControlSelection = LOAD_CONTROLS;
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

    protected void ddlDrList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl = (DropDownList)sender;

            if (ddl.SelectedValue != "-1")
            {
                int drId = Int32.Parse(ddl.SelectedValue);
                Lekarz dr = Repository.GetUserByID(drId) as Lekarz;
                ViewState["LekarzId"] = dr.id;
                InitializeTableHours(dr);
                patientDrDataPanel.Visible = true;
                panelDateChoose.Visible = true;
                InitializeDateTable();
            }
            else
            {
                patientDrDataPanel.Visible = false;
                panelDateChoose.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }
}