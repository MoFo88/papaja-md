using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Drawing;
using System.Web.UI.HtmlControls;

public partial class MyReservations : System.Web.UI.Page
{
    private int reservationsCount;
    private DateTime[] reservationDates;
    private Control[] reservationLabels;
    private Uzytkownik user = null;

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

            if (!Page.IsPostBack)
            {
                InitializeDateTextBoxDefaultData();
                InitializeTableHours();
                //ViewState[VIEWSTATEKEY_DYNCONTROL] = "";
            }
            InitializeDateTable();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
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
            InitializeDateTable();

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
        int lekId = Int32.Parse(Session["userId"].ToString());
        Lekarz lek = Repository.GetUserByID(lekId) as Lekarz;

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
            string hour = reservationHour.ToShortTimeString();
            for (int i = 0; i < days.Count(); i++)
            {
                DateTime dt = Convert.ToDateTime(tbFirstDayOfWeek.Text + " " + hour);
                dt = dt.AddDays(i);
                reservationDates[index] = dt;
                index++;
            }
            workHoursCount = workHoursCount.Subtract(consultationLength);
            reservationHour = reservationHour.Add(consultationLength);
        }
        ColorLinks();//zwiera podmiane kontrolek dalego musi byc wykonane w innym miejscu i przed wrzuceniem do tabeli

        index = 0;
        workHoursCount = latest - earliest;
        reservationHour = earliest;

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
                tc.Controls.Add(reservationLabels[index]);
                index++;
                tc.HorizontalAlign = HorizontalAlign.Center;
                tr.Cells.Add(tc);
            }

            reservationTable.Rows.Add(tr);
            workHoursCount = workHoursCount.Subtract(consultationLength);
            reservationHour = reservationHour.Add(consultationLength);
        }
        panelDatesTable.Controls.Add(reservationTable);
        panelDatesTable.Visible = true;
    }

    private void ColorLinks()
    {
        int lekId = Int32.Parse(Session["userId"].ToString());
        Lekarz lek = Repository.GetUserByID(lekId) as Lekarz;

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
                        if (reservationDates[index].TimeOfDay >= od_.TimeOfDay &&
                            reservationDates[index].TimeOfDay < do_.TimeOfDay)
                        {
                            ((Label)reservationLabels[index]).ForeColor = Color.Green;
                            ((Label)reservationLabels[index]).Text = "Wolny";
                        }
                    }
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
                            LinkButton lb = new LinkButton();
                            lb.ID = "lbReservation_" + i + "_" + p.id;
                            lb.ForeColor = Color.Red;
                            lb.Text = p.Name;
                            lb.Click += this.lbSignIn_Click;
                            panelDatesTable.Controls.Remove(reservationLabels[i]);
                            reservationLabels[i] = lb;
                            panelDatesTable.Controls.Add(reservationLabels[i]);
                        }
                    }
                }
            }
        }
    }

    protected void lbSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;
            string[] idSplit = lb.ID.Split('_');
            int value = Int32.Parse(idSplit.Last());

            Session["patientId"] = value;
            Response.Redirect("~/PatientFile.aspx");
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
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
        reservationLabels = new Control[reservationsCount];
        reservationDates = new DateTime[reservationsCount];

        int lekId = Int32.Parse(Session["userId"].ToString());
        Lekarz lek = Repository.GetUserByID(lekId) as Lekarz;


        for (int i = 0; i < reservationsCount; i++)
        {
            Label lbl = new Label();
            lbl.ID = "lblReservation_" + i.ToString();
            lbl.Text = "Nie przyjmuje";
            lbl.ForeColor = Color.Gray;
            lbl.Visible = true;
            reservationLabels[i] = lbl;
            panelDatesTable.Controls.Add(reservationLabels[i]);

        }
        //this.DynamicControlSelection = LOAD_CONTROLS;
    }

    protected void InitializeTableHours()
    {
        try
        {
            int lekId = Int32.Parse(Session["userId"].ToString());
            Lekarz lek = Repository.GetUserByID(lekId) as Lekarz;
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
}