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
    RoleManager<IdentityRole> roleMgr;
    protected void Page_Load(object sender, EventArgs e)
    {
        // AddUserAndRole();
        ApplicationDbContext context = new ApplicationDbContext();
        // Create a RoleStore object by using the ApplicationDbContext object. 
        // The RoleStore is only allowed to contain IdentityRole objects.
        var roleStore = new RoleStore<IdentityRole>(context);

        

        if (!IsPostBack)
        {
            ApplicationGroupManager roleMgr = new ApplicationGroupManager();

                //roleGroupList.Items.Clear();
                List<ApplicationGroup> groupRoles = roleMgr.Groups.ToList().OrderBy(x => x.Name).ToList();
                ApplicationUtilities.updateListControl(roleDDL, groupRoles, "Id", "Name");
        }
        
        
        
        
       // Microsoft.AspNet.Identity.IRoleStore
        //Microsoft.AspNet.Identity.RoleManager

        // roles.Items.Add(item);
    }

    protected void Register_Click(object sender, EventArgs e)
    {

        ApplicationDbContext context = new ApplicationDbContext();
        // Create a RoleStore object by using the ApplicationDbContext object. 
        // The RoleStore is only allowed to contain IdentityRole objects.
       // RoleStore< IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
        ApplicationGroupManager roleMgr = new ApplicationGroupManager();

        UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        
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

        roleMgr.SetUserGroups(appUser.Id, roleDDL.SelectedValue);
       /* ApplicationGroup currentGroupRole = roleMgr.Groups.ToList().Find(X => X.Id.Equals(roleDDL.SelectedValue));
        ApplicationGroupManager roleManager = new ApplicationGroupManager();
        ApplicationUserGroup userGroup = new ApplicationUserGroup();
        userGroup.ApplicationGroupId = currentGroupRole.Id;
        userGroup.ApplicationUserId = appUser.Id;
        currentGroupRole.ApplicationUsers.Add(userGroup);
        roleMgr.UpdateGroup(currentGroupRole);*/

       // result = userMgr.AddToRole(userMgr.FindByName(appUser.UserName).Id, roleDDL.SelectedValue);

    
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