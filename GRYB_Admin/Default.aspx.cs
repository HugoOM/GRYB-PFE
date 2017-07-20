using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Pour plus de détails, voir http://asp.net-tutorials.com/localization/introduction/
        // Technique 1 -- fortement typé
        testLocalization2.Text = Resources.General.testCodeBehind;
        // Technique 2
        testLocalization2.Text = GetGlobalResourceObject("General", "testCodeBehind").ToString();
    }
}