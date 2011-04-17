using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Root
/// </summary>
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

}