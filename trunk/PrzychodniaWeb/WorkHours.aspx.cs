using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Web.UI.HtmlControls;

public partial class WorkHours : System.Web.UI.Page
{
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
            ViewState[VIEWSTATEKEY_DYNCONTROL] = "";
        }

        if (this.DynamicControlSelection == LOAD_CONTROLS)
        {
            InitializeWorkHoursTbs();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (this.DynamicControlSelection == LOAD_CONTROLS)
            {
                InitializeWorkHoursTbs();
            }
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
                        lblDay1.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + "<br>";
                        break;
                    case 2:
                        lblDay2.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + "<br>";
                        break;
                    case 3:
                        lblDay3.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + "<br>";
                        break;
                    case 4:
                        lblDay4.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + "<br>";
                        break;
                    case 5:
                        lblDay5.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + "<br>";
                        break;
                    case 6:
                        lblDay6.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + "<br>";
                        break;
                    case 7:
                        lblDay7.Text += od_.ToShortTimeString() + "-" + do_.ToShortTimeString() + "<br>";
                        break;
                    default:
                        throw new BadDayIdentifyierException();
                }
            }
            workHoursPanel.Visible = true;
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void InitializeWorkHoursTbs()
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

        editWorkHoursPanel.Controls.Clear();

        List<Godziny_przyj> hours = lek.Godziny_przyjs.ToList();
        foreach (Godziny_przyj g in hours)
        {
            HtmlGenericControl fieldSet = new HtmlGenericControl("fieldset");
            HtmlGenericControl legend = new HtmlGenericControl("legend");
            HtmlGenericControl p = new HtmlGenericControl("p");
            TextBox tbBegin = new TextBox();
            TextBox tbEnd = new TextBox();
            Button btnDel = new Button();
            Button btnSave = new Button();
            string day = g.Dzien1.dzien;
            string _od = g.godz_od.ToString();
            string _do = g.godz_do.ToString();
            DateTime od_ = Convert.ToDateTime(_od);
            DateTime do_ = Convert.ToDateTime(_do);

            legend.InnerText = day;
            fieldSet.Controls.Add(legend);
            fieldSet.Controls.Add(new LiteralControl("Godziny przyjęć:<br/>"));
            tbBegin.Text = od_.ToShortTimeString();
            tbBegin.Width = 140;
            tbEnd.Text = do_.ToShortTimeString();
            tbEnd.Width = 140;
            fieldSet.Controls.Add(new LiteralControl("od: "));
            fieldSet.Controls.Add(tbBegin);
            fieldSet.Controls.Add(new LiteralControl(" do: "));
            fieldSet.Controls.Add(tbEnd);
            fieldSet.Controls.Add(new LiteralControl("<br/>"));
            p.Attributes.Add("class", "submitButton");
            btnDel.ID = "btnDelete_" + g.id;
            btnDel.Click += this.btnDelete_Click;
            btnDel.Attributes.Add("onclick", "javascript:if(confirm('Czy na pewno chcesz usunąć wybraną rejestrację?')== false) return false;");
            btnDel.Text = "Usuń";
            btnDel.CssClass = "submitButton";
            p.Controls.Add(btnDel);
            p.Controls.Add(new LiteralControl(" "));
            btnSave.ID = "btnSave_" + g.id;
            btnSave.Click += this.btnSave_Click;
            btnSave.Attributes.Add("onclick", "javascript:if(confirm('Czy jesteś pewnien, że chcesz zapisać zmiany?')== false) return false;");
            btnSave.Text = "Zapisz";
            btnSave.CssClass = "submitButton";
            p.Controls.Add(btnSave);
            fieldSet.Controls.Add(p);
            editWorkHoursPanel.Controls.Add(fieldSet);
        }
        this.DynamicControlSelection = LOAD_CONTROLS;
        editWorkHoursPanel.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //Button btn = (Button)sender;
            //string[] idSplit = btn.ID.Split('_');
            //int resId = Int32.Parse(idSplit.Last());

            //Repository.DeleteReservation(resId);
            //Master.Message = "Poprawnie usunięto rejestrację";
            //Master.SetMessageColor(Color.Green);
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //Button btn = (Button)sender;
            //string[] idSplit = btn.ID.Split('_');
            //int resId = Int32.Parse(idSplit.Last());

            //Repository.DeleteReservation(resId);
            //Master.Message = "Poprawnie usunięto rejestrację";
            //Master.SetMessageColor(Color.Green);
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
                InitializeWorkHoursTbs();
            }
            else
            {
                workHoursPanel.Visible = false;
                editWorkHoursPanel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }
}