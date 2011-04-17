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

        if (Session["UserId"] == null)
        {
            Page.Response.Redirect("/PrzychodniaWeb/Login.aspx");
        }

        List<Specjalizacja> specjalizationList = Repository.GetAllSpecjalizations();
        Specjalizacja specialization = specjalizationList.First();
        
        DropDownList1.DataSource = specjalizationList; 
        DropDownList1.DataTextField = "nazwa";
        DropDownList1.DataValueField = "id";
        DropDownList1.DataBind();
 
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
     
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {

        int id = Int32.Parse( DropDownList1.SelectedValue.ToString() );

        Specjalizacja specjalizacja = Repository.GetSpecializationById( id );
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