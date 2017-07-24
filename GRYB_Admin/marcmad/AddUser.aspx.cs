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
        ApplicationDbContext context = new ApplicationDbContext();
        var roleStore = new RoleStore<IdentityRole>(context);

      //  groupMgr = new ApplicationGroupManager();
       // userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        if (!IsPostBack)
        {
            ApplicationGroupManager groupMgr = new ApplicationGroupManager();
                List<ApplicationGroup> groupRoles = groupMgr.Groups.ToList().OrderBy(x => x.Name).ToList();
                ApplicationUtilities.updateListControl(roleDDL, groupRoles, "Id", "Name");
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        ApplicationGroupManager groupMgr = new ApplicationGroupManager();
        UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        ApplicationUser appUser = new ApplicationUser
        {
            UserName = UserName.Text,
        };
        IdentityResult result = userMgr.Create(appUser, Password.Text);
        if (!result.Succeeded)
        {
            SuccessMessage.Text = "";
            ErrorMessage.Text = result.Errors.FirstOrDefault();
            return;
        }

        groupMgr.SetUserGroups(appUser.Id, roleDDL.SelectedValue);
        groupMgr.GetUserGroupRoles(appUser.Id);
        
        if (!result.Succeeded)
        {
            SuccessMessage.Text = "";
            ErrorMessage.Text = result.Errors.FirstOrDefault();
            return;
        }

        ErrorMessage.Text = "";
        SuccessMessage.Text = "User added successfully";
    }
}