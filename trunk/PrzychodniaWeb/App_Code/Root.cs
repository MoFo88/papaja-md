using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Collections.Specialized;
using AjaxControlToolkit;
using System.Web.Services;

/// <summary>
/// Summary description for Root
/// /// </summary>

public class Root
{
    
	public Root()
	{
		
	}

    public static void ResetFormControlValues(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControlValues(c);
            }
            else
            {

                if (c is System.Web.UI.WebControls.TextBox)
                {
                    ((TextBox)c).Text = "";
                    return;
                }
                if (c is System.Web.UI.WebControls.CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                    return;
                }
                if (c is System.Web.UI.WebControls.RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                    return;
                }            
            }
        }
    }


    public static void InitializeEditDataPanel(Panel panel, Uzytkownik user)
    {
        TextBox tbEditCity = (TextBox)panel.FindControl("tbEditCity");
        TextBox tbEditEmail = (TextBox)panel.FindControl("tbEditEmail");
        TextBox tbEditPhone = (TextBox)panel.FindControl("tbEditPhone");
        TextBox tbEditPostalCode = (TextBox)panel.FindControl("tbEditPostalCode");
        TextBox tbEditStreet = (TextBox)panel.FindControl("tbEditStreet");
        TextBox tbEditStreetNr = (TextBox)panel.FindControl("tbEditStreetNr");
        TextBox tbPassword = (TextBox)panel.FindControl("tbPassword");
        TextBox tbConfPassword = (TextBox)panel.FindControl("tbConfPassword");
        TextBox tbEditLogin = (TextBox)panel.FindControl("tbEditLogin");
        TextBox tbEditSurname = (TextBox)panel.FindControl("tbEditSurname");
        TextBox tbEditName = (TextBox)panel.FindControl("tbEditName");
        TextBox tbEditPesel = (TextBox)panel.FindControl("tbEditPesel");

        tbEditCity.Text = user.miasto;
        tbEditPhone.Text = user.telefon;
        tbEditPostalCode.Text = user.kod_pocztowy;
        tbEditStreet.Text = user.ulica;
        tbEditStreetNr.Text = user.nr_domu;
        tbPassword.Text = user.password;
        tbConfPassword.Text = user.password;
        tbEditLogin.Text = user.login;
        tbEditSurname.Text = user.nazwisko;
        tbEditName.Text = user.imie;

        try
        {
            tbEditPesel.Text = user.pesel.ToString();
        }
        catch (Exception ex)
        {
            tbEditPesel.Text = "";
        }


        if (user is Administrator)
        {
            tbEditEmail.Text = (user as Administrator).email;
        }

        if (user is Lekarz)
        {
            tbEditEmail.Text = (user as Lekarz).email;
        }
    }

    public List<Lekarz> GetAllDrDdList()
    {
        List<Lekarz> drList = Repository.GetAllDoctors();
        drList.Add(new NullObjectDr());

        return drList;
    }

    

}