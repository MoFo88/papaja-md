using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

public partial class AddNewDoctor : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Specjalizacja> specjalizationList = Repository.GetAllSpecjalizations();
        Specjalizacja specialization = specjalizationList.First();
        DropDownList1.DataSource = specjalizationList;
        DropDownList1.DataTextField = "nazwa";
        DropDownList1.DataBind();

        ViewState["SpecId"] = specialization.id;
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        Specjalizacja specjalizacja = Repository.GetSpecializationById( Int32.Parse( ViewState["SpecId"].ToString() ));

        decimal p = decimal.Parse(TbPesel.Text);

        Repository.AddNewDoctor
        (
            TbImie.Text, 
            TbNazwisko.Text, 
            TbEmail.Text, 
            TbKodKocztowy.Text, 
            TbMiasto.Text, 
            TbNrDomu.Text, 
            p, 
            TbTelefon.Text, 
            TbUlica.Text, 
            specjalizacja.id, 
            TbLogin.Text, 
            TbPassword.Text
        );
    }
}