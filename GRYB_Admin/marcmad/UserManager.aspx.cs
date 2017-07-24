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
using System.Web.Http;

[Authorize(Roles = RolePermission.removeUser)]
public partial class MemberPages_UserAndRoleManager : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        hideAllActionMessages();
        if (!IsPostBack)
        {
            ApplicationGroupManager groupRoleManager = new ApplicationGroupManager();
            List<ApplicationGroup> groupRoles = groupRoleManager.Groups.ToList().OrderBy(x => x.Name).ToList();
            refreshUserDDList(new ApplicationDbContext());
            ApplicationUtilities.updateListControl(roleDDL, groupRoles, "Id", "Name");
        }
    }
    private void refreshUserDDList(ApplicationDbContext context)
    {
        List<ApplicationUser> userList = context.Users.ToList();
        userList.Insert(0, new ApplicationUser("Select a user"));
        ApplicationUtilities.updateListControl(userDDList, context.Users.ToList(), "Id", "UserName");
        (userDDList as IPostBackDataHandler).RaisePostDataChangedEvent(); // refresh other fields
    }

    protected void passwordResetLink_Click(object sender, EventArgs e)
    {
        
        if (passwordResetDiv.Visible)
            passwordResetDiv.Visible = false;
        else
            passwordResetDiv.Visible = true;
    }


    protected void userDDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationGroupManager groupRoleManager = new ApplicationGroupManager();
          UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        if (context.Users.ToList().Count == 0 || getSelectedUser(userManager) == null)
        {
            userDiv.Visible = false;
            return;
        }
        
            userDiv.Visible = true;
        
        
      
        List<ApplicationUser> users = context.Users.ToList();
        ApplicationUser selectedUser = getSelectedUser(userManager);
            userName.Text = selectedUser.UserName;

        try
        {
            
            roleDDL.SelectedValue = groupRoleManager.GetUserGroups(selectedUser.Id).First().Id;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private ApplicationUser getSelectedUser(UserManager<ApplicationUser> userManager)
    {

        if (userDDList.SelectedIndex == -1)
        {
            return null;
        }
        else
        {
            return userManager.FindById(userDDList.SelectedValue);
        }
    }
    private void hideAllActionMessages()
    {
        passwordResetsuccess.Visible = false;
        passwordResetError.Visible = false;
        userDeletedSuccess.Visible = false;
        userDeletedError.Visible = false;
        UserModificationSuccess.Visible = false;
        UserModificationError.Visible = false;
        
    }

    [Authorize(Roles = RolePermission.manageUser)]
    protected void changePasswordButton_Click(object sender, EventArgs e)
    {
        ApplicationDbContext context = new ApplicationDbContext();
        UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        passwordResetDiv.Visible = false;
        ApplicationUser user = getSelectedUser(userManager);
        if (user == null)
        {
            userDeletedError.Visible = true;
            userDeletedError.Text = "User deletion failed. The user could not be found";
            return;
        }
        UserStore<ApplicationUser> store = new UserStore<ApplicationUser>();
        IdentityResult result  = userManager.PasswordValidator.ValidateAsync(Password.Text).Result;
        if (!result.Succeeded)
        {
            passwordResetError.Visible = true;
            passwordResetError.Text = "failed to change the password: " + result.Errors.FirstOrDefault();
            return;
        }
        String hashedPassword = userManager.PasswordHasher.HashPassword(Password.Text);
        store.SetPasswordHashAsync(user, hashedPassword);



        result = userManager.Update(user);
        if (result.Succeeded)
        {
            passwordResetsuccess.Visible = true;
        }
        else
        {
            passwordResetError.Visible = true;
            passwordResetError.Text = "failed to change the password: " + result.Errors.FirstOrDefault();
        }
        


    }
    [Authorize(Roles = RolePermission.manageUser)]
    protected void btnSave_Click(object sender, EventArgs e)
    {
           ApplicationDbContext context = new ApplicationDbContext();
          UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        ApplicationGroupManager groupRoleManager = new ApplicationGroupManager();
        ApplicationUser user = getSelectedUser(userManager);
        if (user == null)
        {
            userDeletedError.Visible = true;
            userDeletedError.Text = "User deletion failed. The user could not be found";
            return;
        } 

        List<ApplicationGroup> groupRoles = groupRoleManager.Groups.ToList();
        
        ApplicationGroupRole groupRole = new ApplicationGroupRole();
        ApplicationGroup previousGroupRole = groupRoleManager.GetUserGroups(user.Id).First();
        
        ApplicationGroup currentGroupRole = groupRoleManager.Groups.ToList().Find(X => X.Id.Equals(roleDDL.SelectedValue));
        IdentityResult result = groupRoleManager.SetUserGroups(user.Id, currentGroupRole.Id);
        if (!result.Succeeded)
        {
            
                UserModificationError.Visible = true;
                UserModificationError.Text = "Could not modify the user " + result.Errors.FirstOrDefault();
                return;
            
        }
        else
        {
            UserModificationSuccess.Visible = true;
        }

        
    }

    [Authorize(Roles = RolePermission.removeUser)]
    protected void deleteUser_Click(object sender, EventArgs e)
    {
        ApplicationGroupManager groupRoleManager = new ApplicationGroupManager();
        ApplicationDbContext context = new ApplicationDbContext();
        UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        ApplicationUser user = getSelectedUser(userManager);
        if (user == null)
        {
            userDeletedError.Visible = true;//.CssClass = "text-danger";
            userDeletedError.Text = "User deletion failed. The user could not be found";
            return;
        }

        IdentityResult result = groupRoleManager.ClearUserGroups(userDDList.SelectedValue);
        if (!result.Succeeded)
        {
            userDeletedError.Visible = true;
            userDeletedError.Text = "User deletion failed with " + result.Errors.FirstOrDefault();
        }
        // Refresh the usermanager to avoid concurrency exception
        context.Dispose();
        context = new ApplicationDbContext();
        userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        
        ApplicationUser user2 = userManager.FindById(userDDList.SelectedValue);
        
         result = userManager.Delete(user2);
        
        if (!result.Succeeded)
        {
            userDeletedError.Visible = true;
            userDeletedError.Text = "User deletion failed with " + result.Errors.FirstOrDefault();
        }
        


        refreshUserDDList(context);
        userDeletedSuccess.Visible = true;// "User successfully deleted";
    }
}
 
 