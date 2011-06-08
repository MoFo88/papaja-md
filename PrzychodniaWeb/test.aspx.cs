using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn.Text = "testuj";
        btn.Click += this.Button1_Click;
        Panel1.Controls.Add(btn);
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        Label1.Text = "i co?";
    }
}