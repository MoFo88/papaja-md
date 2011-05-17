using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Drawing;

public partial class MyAccount : System.Web.UI.Page
{
    private Uzytkownik user = null;
    private Lekarz dr = null;

    private String editMessage;
    public String EditMessage { get { return editMessage; } set { editMessage = value; lblEditMessage.Text = value; } }
    private String passwordChangeMessage;
    public String PasswordChangeMessage { get { return passwordChangeMessage; } set { passwordChangeMessage = value; lblPasswordChangeMessage.Text = value; } }
    private String specMessage;
    public String SpecMessage { get { return specMessage; } set { specMessage = value; lblSpecMessage.Text = value; } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userId"] != null)
            {
                user = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString()));

                if (user is Administrator)
                {
                    Server.Transfer("~/MyAccountAdmin.aspx");
                }

                if (user is Lekarz)
                {
                    dr = user as Lekarz;
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                InitializePanelEditSpec();
                InitializePanelspec();
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor( Color.Red );
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        dr = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString())) as Lekarz;

        String lbl = "Dr @NAME @SURNAME";
        lbl = lbl.Replace("@NAME", dr.imie);
        lbl = lbl.Replace("@SURNAME", dr.nazwisko);

        lblName.Text = lbl;

        lblPesel.Text = dr.pesel.ToString();
        lblEmail.Text = dr.email;
        lblPhone.Text = dr.telefon;
        lblAdres.Text = "ul. " + dr.ulica + " " + dr.nr_domu + ", " + dr.kod_pocztowy + " " + dr.miasto;

        Root.InitializeEditDataPanel(panelEdit, dr);
        InitializeTableHours();
        InitializePanelEditSpec();
        InitializePanelspec();
    }

    protected void InitializePanelspec()
    {
        panelSpec.Controls.Clear();

        List<Specjalizacja> specList = Repository.GetAllDrSpecjalizations(dr);

        Table specTable = new Table();

        TableHeaderRow th = new TableHeaderRow();
        TableHeaderCell thc = new TableHeaderCell();
        thc.Text = "Lista specjalizacji:";

        th.Cells.Add(thc);
        specTable.Rows.Add(th);

        foreach (Specjalizacja s in specList)
        {
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();

            tc.Text = s.nazwa;
            tr.Cells.Add(tc);
            specTable.Rows.Add(tr);
   
        }

        panelSpec.Controls.Add(specTable);
    }

    protected void InitializePanelEditSpec()
    {
        try
        {
            dr = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString())) as Lekarz;

            List<Specjalizacja> specList = Repository.GetAllSpecjalizations();

            cblSpecializations.DataSource = specList;
            cblSpecializations.DataBind();

            foreach (ListItem item in cblSpecializations.Items)
            {
                if (dr.Specjalizacja_Lekarzs.FirstOrDefault(sl => sl.idSpecjalizacja == Int32.Parse( item.Value )) != null)
                {
                    item.Selected = true;
                }
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }

    }
    
    protected void InitializePanelEdit()
    {
        tbEditCity.Text = dr.miasto;
        tbEditEmail.Text = dr.email;
        tbEditPhone.Text = dr.telefon;
        tbEditPostalCode.Text = dr.kod_pocztowy;
        tbEditStreet.Text = dr.ulica;
        tbEditStreetNr.Text = dr.nr_domu;
        tbPassword.Text = dr.password;
        tbConfPassword.Text = dr.password;
        tbEditLogin.Text = dr.login;
        tbEditSurname.Text = dr.nazwisko;
        tbEditName.Text = dr.imie;

        try
        {
            tbEditPesel.Text = dr.pesel.ToString();
        }
        catch (Exception ex)
        {
            tbEditPesel.Text = "";
        }
        
    }

    protected void InitializeTableHours()
    {
        try
        {
            List<Godziny_przyj> hours = dr.Godziny_przyjs.ToList();

            lblDay1.Text = "";
            lblDay2.Text = "";
            lblDay3.Text = "";
            lblDay4.Text = "";
            lblDay5.Text = "";
            lblDay6.Text = "";
            lblDay7.Text = "";


            int sp = 11;

            foreach (Godziny_przyj g in hours)
            {
                switch ( g.dzien )
                {
                    case 1:
                        lblDay1.Text += g.godz_od.ToString().Substring(sp, 5) + "-" + g.godz_do.ToString().Substring(sp, 5) + ", ";
                        break;
                    case 2:
                        lblDay2.Text += g.godz_od.ToString().Substring(sp, 5) + "-" + g.godz_do.ToString().Substring(sp, 5) + ", ";
                        break;
                    case 3:
                        lblDay3.Text += g.godz_od.ToString().Substring(sp, 5) + "-" + g.godz_do.ToString().Substring(sp, 5) + ", ";
                        break;
                    case 4:
                        lblDay4.Text += g.godz_od.ToString().Substring(sp, 5) + "-" + g.godz_do.ToString().Substring(sp, 5) + ", ";
                        break;
                    case 5:
                        lblDay5.Text += g.godz_od.ToString().Substring(sp, 5) + "-" + g.godz_do.ToString().Substring(sp, 5) + ", ";
                        break;
                    case 6:
                        lblDay6.Text += g.godz_od.ToString().Substring(0, 5) + "-" + g.godz_do.ToString().Substring(0, 5) + ", ";
                        break;
                    case 7:
                        lblDay7.Text += g.godz_od.ToString().Substring(0, 5) + "-" + g.godz_do.ToString().Substring(0, 5) + ", ";
                        break;
                    default:
                        throw new BadDayIdentifyierException();
                }
            }          
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    

    protected void btnSubmitEdit_Click(object sender, EventArgs e)
    {
        try
        {
            dr = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString())) as Lekarz;

            String login = tbEditLogin.Text; 
            String city = tbEditCity.Text;
            String email = tbEditEmail.Text;
            String name = tbEditName.Text;
            
            Decimal? pesel = null;
            try
            {
                pesel = Decimal.Parse(tbEditPesel.Text);
            }
            catch (Exception ex)
            {
                pesel = null;
            }

            String phone =  tbEditPhone.Text;
            String postalCode = tbEditPostalCode.Text;
            String street = tbEditStreet.Text;
            String streetNr = tbEditStreetNr.Text;
            String surname = tbEditSurname.Text;

            Repository.UpdateDrData(dr, name, surname, email, postalCode, city, streetNr, pesel, phone, street, null, login);

            EditMessage = "Dane poprawnie zmienione.";
            lblEditMessage.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            EditMessage = ex.Message;
            lblEditMessage.ForeColor = Color.Red;
        }
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            dr = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString())) as Lekarz;


            String password = tbPassword.Text;
            String confPassword = tbConfPassword.Text;

            if (password != confPassword) throw new PasswordDontMatchException();

            Repository.ChangeUserPassword(dr, password);

            PasswordChangeMessage = "Hasło poprawnie zmienione.";
            lblPasswordChangeMessage.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            PasswordChangeMessage = ex.Message;
            lblPasswordChangeMessage.ForeColor = Color.Red;
        }
    }
    
    protected void btnEditSpec_Click(object sender, EventArgs e)
    {
        try
        {
            dr = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString())) as Lekarz;
            
            Repository.RemoveAllDrSpecjalizations(dr);

            foreach (ListItem item in cblSpecializations.Items)
            {
                if (item.Selected)
                {
                    int idSpec = Int32.Parse(item.Value);
                    Repository.AddSpecjalization(dr, idSpec);
                }
            }

            SpecMessage = "Lista specjalizacji została zaktualizowana.";
            lblSpecMessage.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            SpecMessage = ex.Message;
            lblSpecMessage.ForeColor = Color.Red;
        }
    }
}