using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using GRYB_Admin;

public partial class MemberPages_UserAndRoleManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        { 
            ApplicationUtilities.updateListControl(roleDDL, new IdentityManager().GetRoles(), "id", "name");
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        IdentityManager manager = new IdentityManager();
        User user = new User();
        user.name = UserName.Text;
        user.setPasswordHash(Password.Text, false);
        try
        {


            user.role = manager.GetRole(roleDDL.SelectedValue);
            IdentityResult result = manager.CreateUser(user);
            if (!result.Succeeded)
            {
                SuccessMessage.Text = "";
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                return;
            }

            ErrorMessage.Text = "";
            SuccessMessage.Text = Resources.General.UserAddedSuccessfully;
        }
        catch (Exception ex)
        {
            ErrorMessage.Text = Resources.General.AnErrorHasOccured + ": " +  ex.ToString();
        }

    }
}