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
    protected Uzytkownik user = null;
    protected Lekarz dr = null;

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

    protected void InitializePanelEdit()
    {
        tbEditCity.Text = dr.miasto;
        tbEditEmail.Text = dr.email;
        tbEditPhone.Text = dr.telefon;
        tbEditPostalCode.Text = dr.kod_pocztowy;
        tbEditStreet.Text = dr.ulica;
        tbEditStreetNr.Text = dr.nr_domu;

        try
        {
            tbEditPesel.Text = dr.pesel.ToString();
        }
        catch (Exception ex)
        {
            tbEditPesel.Text = "";
        }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Session["userId"] != null)
                {
                    user = Repository.GetUserByID(Int32.Parse(Session["userId"].ToString()));
                    dr = user as Lekarz;

                    String lbl = "Dr @NAME @SURNAME";
                    lbl = lbl.Replace("@NAME", dr.imie);
                    lbl = lbl.Replace("@SURNAME", dr.nazwisko);

                    lblName.Text = lbl;

                    InitializePanelspec();

                    lblPesel.Text = dr.pesel.ToString();
                    lblEmail.Text = dr.email;
                    lblPhone.Text = dr.telefon;
                    lblAdres.Text = "ul. " + dr.ulica + " " + dr.nr_domu + ", " + dr.kod_pocztowy + " " + dr.miasto;

                    InitializePanelEdit();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor( Color.Red );
        }
    }
}