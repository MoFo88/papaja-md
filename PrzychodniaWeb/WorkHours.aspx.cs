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
    Administrator admin = null;
    Uzytkownik user = null;
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
        try
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
                InitializeDDL();
                InitializeDayDDL();
                ViewState[VIEWSTATEKEY_DYNCONTROL] = "";
            }

            if (this.DynamicControlSelection == LOAD_CONTROLS)
            {
                InitializeWorkHoursTbs();
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
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
        hours = hours.OrderBy(d => d.Dzien1.id).ThenBy(s => s.godz_od).ToList();
        foreach (Godziny_przyj g in hours)
        {
            HtmlGenericControl fieldSet = new HtmlGenericControl("fieldset");
            HtmlGenericControl legend = new HtmlGenericControl("legend");
            HtmlGenericControl p = new HtmlGenericControl("p");
            TextBox tbBegin = new TextBox();
            TextBox tbEnd = new TextBox();
            tbBegin.ID = "tbBegin_" + g.id;
            tbEnd.ID = "tbEnd_" + g.id;
            Button btnDel = new Button();
            Button btnSave = new Button();
            string day = g.Dzien1.dzien;
            string _od = g.godz_od.ToString();
            string _do = g.godz_do.ToString();
            DateTime od_ = Convert.ToDateTime(_od);
            DateTime do_ = Convert.ToDateTime(_do);

            //text and TBs
            legend.InnerText = day;
            fieldSet.Controls.Add(legend);
            fieldSet.Controls.Add(new LiteralControl("Godziny przyjęć:<br/>"));
            tbBegin.Text = od_.ToShortTimeString();
            tbBegin.Width = 140;
            tbEnd.Text = do_.ToShortTimeString();
            tbEnd.Width = 140;
            fieldSet.Controls.Add(new LiteralControl("od: "));
            fieldSet.Controls.Add(tbBegin);

            //Validators
            RequiredFieldValidator beginReqVal = new RequiredFieldValidator();
            RegularExpressionValidator beginRegExVal = new RegularExpressionValidator();
            RequiredFieldValidator endReqVal = new RequiredFieldValidator();
            RegularExpressionValidator endRegExVal = new RegularExpressionValidator();
            CompareValidator endCompVal = new CompareValidator();

            beginReqVal.ID = "beginRequiredValidator_" + g.id;
            beginReqVal.ControlToValidate = "tbBegin_" + g.id;
            beginReqVal.CssClass = "failureNotification";
            beginReqVal.Display = ValidatorDisplay.Dynamic;
            beginReqVal.ErrorMessage = "Godzina rozpoczęcia jest wymagana.";
            beginReqVal.ToolTip = "Godzina rozpoczęcia jest wymagana.";
            beginReqVal.ValidationGroup = "workHoursValidationGroup";
            beginReqVal.Text = "*";

            beginRegExVal.ID = "beginRegExValidator_" + g.id;
            beginRegExVal.ControlToValidate = "tbBegin_" + g.id;
            beginRegExVal.CssClass = "failureNotification";
            beginRegExVal.Display = ValidatorDisplay.Dynamic;
            beginRegExVal.ErrorMessage = "Godzina powinna być podana w formacie GG:mm";
            beginRegExVal.ToolTip = "Godzina powinna być podana w formacie GG:mm";
            beginReqVal.ValidationGroup = "workHoursValidationGroup";
            beginRegExVal.ValidationExpression = @"\d\d:\d\d";
            beginRegExVal.Text = "*";
            fieldSet.Controls.Add(beginRegExVal);
            fieldSet.Controls.Add(beginReqVal);

            endReqVal.ID = "endRequiredValidator_" + g.id;
            endReqVal.ControlToValidate = "tbEnd_" + g.id;
            endReqVal.CssClass = "failureNotification";
            endReqVal.Display = ValidatorDisplay.Dynamic;
            endReqVal.ErrorMessage = "Godzina końca jest wymagana.";
            endReqVal.ToolTip = "Godzina końca jest wymagana.";
            endReqVal.ValidationGroup = "workHoursValidationGroup";
            endReqVal.Text = "*";

            endRegExVal.ID = "endRegExValidator_" + g.id;
            endRegExVal.ControlToValidate = "tbEnd_" + g.id;
            endRegExVal.CssClass = "failureNotification";
            endRegExVal.Display = ValidatorDisplay.Dynamic;
            endRegExVal.ErrorMessage = "Godzina powinna być podana w formacie GG:mm";
            endRegExVal.ToolTip = "Godzina powinna być podana w formacie GG:mm";
            endRegExVal.ValidationGroup = "workHoursValidationGroup";
            endRegExVal.ValidationExpression = @"\d\d:\d\d";
            endRegExVal.Text = "*";

            endCompVal.ID = "endCompValalidator_" + g.id;
            endCompVal.ControlToValidate = "tbEnd_" + g.id;
            endCompVal.ControlToCompare = "tbBegin_" + g.id;
            endCompVal.Display = ValidatorDisplay.Dynamic;
            endCompVal.ErrorMessage = "Godzina końca musi być późniejsza niż godzina rozpoczęcia.";
            endCompVal.ToolTip = "Godzina końca musi być późniejsza niż godzina rozpoczęcia.";
            endCompVal.ValidationGroup = "workHoursValidationGroup";
            endCompVal.Operator = ValidationCompareOperator.GreaterThan;
            endCompVal.Text = "*";

            fieldSet.Controls.Add(endRegExVal);
            fieldSet.Controls.Add(endReqVal);
            fieldSet.Controls.Add(new LiteralControl(" do: "));
            fieldSet.Controls.Add(tbEnd);
            fieldSet.Controls.Add(new LiteralControl("<br/>"));

            //buttons
            p.Attributes.Add("class", "submitButton");
            btnDel.ID = "btnDelete_" + g.id;
            btnDel.Click += this.btnDelete_Click;
            btnDel.Attributes.Add("onclick", "javascript:if(confirm('Czy na pewno chcesz usunąć wybraną rejestrację?')== false) return false;");
            btnDel.Text = "Usuń";
            btnDel.ValidationGroup = "workHoursValidationGroup";
            p.Controls.Add(btnDel);
            p.Controls.Add(new LiteralControl(" "));
            btnSave.ID = "btnSave_" + g.id;
            btnSave.Click += this.btnSave_Click;
            btnSave.Attributes.Add("onclick", "javascript:if(confirm('Czy jesteś pewnien, że chcesz zapisać zmiany?')== false) return false;");
            btnSave.Text = "Zapisz";
            btnSave.ValidationGroup = "workHoursValidationGroup";
            p.Controls.Add(btnSave);
            fieldSet.Controls.Add(p);
            editWorkHoursPanel.Controls.Add(fieldSet);
        }
        this.DynamicControlSelection = LOAD_CONTROLS;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
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

            Button btn = (Button)sender;
            string[] idSplit = btn.ID.Split('_');
            int godzId = Int32.Parse(idSplit.Last());
            TextBox tbb = (TextBox)FindControl("ctl00$MainContent$tbBegin_" + godzId);
            TextBox tbe = (TextBox)FindControl("ctl00$MainContent$tbEnd_" + godzId);
            string begin = tbb.Text;
            string end = tbe.Text;

            Repository.UpdateHours(godzId, begin, end);
            InitializeTableHours(lek);
            Master.Message = "Poprawnie zmieniono godziny przyjęć";
            Master.SetMessageColor(Color.Green);
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

            Button btn = (Button)sender;
            string[] idSplit = btn.ID.Split('_');
            int godzId = Int32.Parse(idSplit.Last());

            Repository.DeleteHours(godzId);
            InitializeTableHours(lek);
            Master.Message = "Poprawnie usunięto godziny przyjęć";
            Master.SetMessageColor(Color.Green);
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
                editWorkHoursPanel.Visible = true;
                newWorkHoursPanel.Visible = true;

                InitializeTableHours(dr);
                InitializeWorkHoursTbs();
            }
            else
            {
                workHoursPanel.Visible = false;
                editWorkHoursPanel.Visible = false;
                newWorkHoursPanel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }

    protected void InitializeDayDDL()
    {
        try
        {
            List<Dzien> dzienList = Repository.GetAllDays();

            ddlDay.DataSource = dzienList;
            ddlDay.DataValueField = "id";
            ddlDay.DataTextField = "dzien";
            ddlDay.DataBind();

            ListItem itm = new ListItem();
            itm.Text = "Wybierz dzień tygodnia";
            itm.Value = "-1";

            ddlDay.Items.Insert(0, itm);
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void btnAddNewHours_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlDay.SelectedValue == "-1")
            {
                lblAddResult.ForeColor = Color.Red;
                lblAddResult.Text = "Należy wybrać dzień tygodnia";
                return;
            }
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

            string begin = tbBegin.Text;
            string end = tbEnd.Text;
            int dayId = Int32.Parse(ddlDay.SelectedValue);

            bool res = Repository.AddNewHours
            (
                lek.id,
                dayId,
                begin,
                end
            );

            ddlDay.SelectedIndex = 0;
            tbBegin.Text = "";
            tbEnd.Text = "";
            InitializeTableHours(lek);

            if (res)
            {
                lblAddResult.ForeColor = Color.Green;
                lblAddResult.Text = "Rejestrację dodano poprawnie";
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(System.Drawing.Color.Red);
        }
    }
}