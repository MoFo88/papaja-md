using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewReservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearchPatient_Click(object sender, EventArgs e)
    {
        string login = tbLogin.Text;
        decimal pesel = Decimal.Parse(tbPesel.Text);
    }
}