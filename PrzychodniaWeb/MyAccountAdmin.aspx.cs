using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Drawing;


public partial class MyAccountAdmin : System.Web.UI.Page
{
    Administrator admin = null;
    Uzytkownik user = null;

    private string pwdMessage;
    public string PwdMessage { get { return pwdMessage; } set { pwdMessage = value; lblPasswordChangeMessage.Text = value; } }
    private String editMessage;
    public String EditMessage { get { return editMessage; } set { editMessage = value; lblEditMessage.Text = value; } }

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
            admin = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString())) as Administrator;

            lblName.Text = admin.imie;
            lblSurname.Text = admin.nazwisko;
            lblPhone.Text = admin.telefon;
            lblEmail.Text = admin.email;

            Root.InitializeEditDataPanel(panelEdit, admin);
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            admin = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString())) as Administrator;

            String password = tbPassword.Text;
            String confPassword = tbConfPassword.Text;

            if (password != confPassword) throw new PasswordDontMatchException();

            Repository.ChangeUserPassword(admin, password);

            PwdMessage = "Hasło poprawnie zmienione.";
            lblPasswordChangeMessage.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            PwdMessage = ex.Message;
            lblPasswordChangeMessage.ForeColor = Color.Red;
        }
    }
    protected void btnSubmitEdit_Click(object sender, EventArgs e)
    {
        try
        {
            admin = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString())) as Administrator;

            String login = tbEditLogin.Text;
            String city = tbEditCity.Text;
            String email = tbEditEmail.Text;
            String name = tbEditName.Text;
            Decimal? pesel = null;
            
            try
            {
                 pesel = Decimal.Parse(tbEditPesel.Text);
            }
            catch(Exception ex)
            {
                pesel = null;
            }

            String phone = tbEditPhone.Text;
            String postalCode = tbEditPostalCode.Text;
            String street = tbEditStreet.Text;
            String streetNr = tbEditStreetNr.Text;
            String surname = tbEditSurname.Text;

            Repository.UpdateAdminData(admin, name, surname, email, postalCode, city, streetNr, pesel, phone, street, login);

            EditMessage = "Dane poprawnie zmienione.";
            lblEditMessage.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            EditMessage = ex.Message;
            lblEditMessage.ForeColor = Color.Red;
        }
    }
}