using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Drawing;

public partial class DrData : System.Web.UI.Page
{

    Lekarz dr = null;
    Uzytkownik user = null;
    Administrator admin = null;

    private String passwordChangeMessage;
    public String PasswordChangeMessage { get { return passwordChangeMessage; } set { passwordChangeMessage = value; lblPasswordChangeMessage.Text = value; } }
    private String specMessage;
    public String SpecMessage { get { return specMessage; } set { specMessage = value; lblSpecMessage.Text = value; } }
    
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


        panelEditPassword.Visible = false;
        panelEditSpec.Visible = false;
        PasswordChangeMessage = "";
        SpecMessage = "";

    }

    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Repository.GetAllDoctors();
    }

    protected void LinqDataSource1_Deleting(object sender, LinqDataSourceDeleteEventArgs e)
    {
        try
        {
            if (e.Exception != null)
            {
                Master.Message = e.Exception.Message;
                Master.SetMessageColor(Color.Red);
                e.ExceptionHandled = true;
            }

            int id = ((Uzytkownik)e.OriginalObject).id;
            Repository.DeleteUser(id);
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void LinqDataSource1_Updating(object sender, LinqDataSourceUpdateEventArgs e)
    {
        try
        {
            Uzytkownik p = e.NewObject as Uzytkownik;
            Repository.UpdateUserData(p);
        }
        catch (Exception ex)
        {
            e.Cancel = true;
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void gridViewDrs_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        try
        {
            if (e.Exception != null)
            {
                Master.Message = e.Exception.Message;
                Master.SetMessageColor(Color.Red);
                e.ExceptionHandled = true;
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }
    protected void gridViewDrs_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        try
        {
            Lekarz p = Repository.GetUserByID(Int32.Parse(e.Keys["id"].ToString())) as Lekarz;

            GridView gv = (GridView)sender;
            GridViewRow gvr = gv.Rows[gv.EditIndex];

            String email = (e.NewValues["email"] == null) ? null : e.NewValues["email"].ToString();

            p.email = email;

            Repository.UpdateDrData(p);

            if (e.Exception != null)
            {
                Master.Message = e.Exception.Message;
                Master.SetMessageColor(Color.Red);
                e.ExceptionHandled = true;
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    protected void gridViewDrs_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int ID = Int32.Parse(gridViewDrs.DataKeys[e.NewEditIndex].Values["id"].ToString());
            Session["drId"] = ID;


            InitializePanelEditSpec();

            panelEditPassword.Visible = true;
            panelEditSpec.Visible = true;
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    
    protected void btnChangePassword_Click1(object sender, EventArgs e)
    {
        try
        {

            dr = Repository.GetUserByID(Int32.Parse(Session["drId"].ToString())) as Lekarz;

            String password = tbPassword.Text;
            String confPassword = tbConfPassword.Text;

            if (password != confPassword) throw new PasswordDontMatchException();

            Repository.ChangeUserPassword(dr, password);

            PasswordChangeMessage = "Hasło poprawnie zmienione.";
            lblPasswordChangeMessage.ForeColor = Color.Green;

            panelEditPassword.Visible = true;
            panelEditSpec.Visible = true;
        }
        catch (Exception ex)
        {
            PasswordChangeMessage = ex.Message;
            lblPasswordChangeMessage.ForeColor = Color.Red;
        }
    }

    protected void InitializePanelEditSpec()
    {
        try
        {
            dr = Repository.GetUserByID(Int32.Parse(Session["drId"].ToString())) as Lekarz;

            List<Specjalizacja> specList = Repository.GetAllSpecjalizations();

            cblSpecializations.DataSource = specList;
            cblSpecializations.DataBind();

            foreach (ListItem item in cblSpecializations.Items)
            {
                if (dr.Specjalizacja_Lekarzs.FirstOrDefault(sl => sl.idSpecjalizacja == Int32.Parse(item.Value)) != null)
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

    protected void btnEditSpec_Click(object sender, EventArgs e)
    {
        try
        {
            dr = Repository.GetUserByID(Int32.Parse(Session["drId"].ToString())) as Lekarz;

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

            panelEditPassword.Visible = true;
            panelEditSpec.Visible = true;
        }
        catch (Exception ex)
        {
            SpecMessage = ex.Message;
            lblSpecMessage.ForeColor = Color.Red;
        }
    }
    protected void gridViewDrs_RowDataBound(object sender, GridViewRowEventArgs e)
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
                                    "if (!confirm('Jesteś pewien że chcesz usunąć tego lekarza?')) return;";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }
}