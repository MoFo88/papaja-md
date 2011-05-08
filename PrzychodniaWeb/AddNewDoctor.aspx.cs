using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Drawing;

public partial class AddNewDoctor : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserId"] == null)
        {
            Page.Response.Redirect("/PrzychodniaWeb/Login.aspx");
        }

        //List<Specjalizacja> specjalizationList = Repository.GetAllSpecjalizations();
        //Specjalizacja specialization = specjalizationList.First();
        InitializeCheckBoxSpec();

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //cblSpecializations.DataBind();
        InitializeCheckBoxSpec();
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        List<int> specializationsIdList = new List<int>();

        try
        {
            decimal decPesel = decimal.Parse(tbPesel.Text);

            foreach (ListItem item in cblSpecializations.Items)
            {
                if (item.Selected)
                {
                    int i = Int32.Parse(item.Value);

                    specializationsIdList.Add(i);
                }
            }

            Repository.AddNewDoctor
            (
                tbImie.Text,
                tbNazwisko.Text,
                tbEmail.Text,
                tbKodPocztowy.Text,
                tbMiasto.Text,
                tbNrDomu.Text,
                decPesel,
                tbTelefon.Text,
                tbUlica.Text,
                specializationsIdList,
                tbLogin.Text,
                tbPassword.Text
            );
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }

        tbImie.Text = "";
        tbNazwisko.Text = "";
        tbEmail.Text = "";
        tbKodPocztowy.Text = "";
        tbMiasto.Text = "";
        tbNrDomu.Text = "";

        tbPesel.Text = "";
        tbTelefon.Text = "";
        tbUlica.Text = "";

        cblSpecializations.Items.Clear();
        tbLogin.Text = "";
        tbPassword.Text = "";


        lblResult.ForeColor = System.Drawing.Color.Green;
        lblResult.Text = "Lekarz został poprawnie dodany";
    }

    protected void InitializeCheckBoxSpec()
    {
        try
        {
            List<Specjalizacja> specList = Repository.GetAllSpecjalizations();

            cblSpecializations.DataSource = specList;
            cblSpecializations.DataBind();
        }
        catch (Exception ex)
        {
            Master.Message = ex.Message;
            Master.SetMessageColor(Color.Red);
        }
    }

    //metoda do wyswietlania wszystkich specjalnosci z bazy - chyba nie potrzebna
    //protected void ShowAllSpecajlizacjas()
    //{
    //    panelSpecializations.Controls.Clear();

    //    Table tableSpecializations = new Table();
    //    tableSpecializations.ID = "TableSpecializations";
    //    panelSpecializations.Controls.Add(tableSpecializations);

    //    //tworzemnie wiersza tabeli z tytułem
    //    TableRow trTitle = new TableRow();
    //    TableCell tcTitle = new TableCell();
    //    Label lbTitle = new Label();

    //    lbTitle.ID = "lbTitle";
    //    lbTitle.Text = "Specjalizacje: ";

    //    tcTitle.Controls.Add(lbTitle);
    //    trTitle.Cells.Add(tcTitle);

    //    List<Specjalizacja> specjalizationsList = Repository.GetAllSpecjalizations();

    //    int i = 0;
    //    foreach (var spec in specjalizationsList)
    //    {
    //        //nowy wiersz tabeli
    //        TableRow tr = new TableRow();
    //        TableCell tc1 = new TableCell();
    //        TableCell tc2 = new TableCell();

    //        //tworzenie labela dla nowej kontrolki
    //        Label newLabel = new Label();
    //        newLabel.ID = "lbSpecialization" + i.ToString();
    //        newLabel.Text = spec.nazwa;
    //        tc1.Controls.Add(newLabel);
    //        tr.Cells.Add(tc1);

    //        //tworzenie checkbox'a dla specjalizacji
    //        CheckBox newCheckBox = new CheckBox();

    //        i++;
    //    }


    //}

    protected void btnAddSpecialization_Click(object sender, EventArgs e)
    {
        string name = tbNewSpecialization.Text;
        Repository.AddNewSpecialization(name);
        tbNewSpecialization.Text = "";

        lblResult.ForeColor = System.Drawing.Color.Green;
        lblResult.Text = "Specjalizacja została poprawnie dodana";
    }
}