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
    ApplicationGroupManager groupRoleManager;
    UserManager<ApplicationUser> userManager;
    ApplicationDbContext context;

    //ApplicationUser selectedUser;
    //IdentityRole previousUserRole;

    protected void Page_Load(object sender, EventArgs e)
    {
       /* AddUserAndRole();
        if (!IsPostBack)
        {
            updateRoleBox();
        }*/
        
        context = new ApplicationDbContext();
        // Create a RoleStore object by using the ApplicationDbContext object. 
        // The RoleStore is only allowed to contain IdentityRole objects.
        var roleStore = new RoleStore<IdentityRole>(context);

        groupRoleManager = new ApplicationGroupManager();
        userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        hideAllActionMessages();
        if (!IsPostBack)
        {
            refreshUserDDList();
            List<ApplicationGroup> groupRoles = groupRoleManager.Groups.ToList().OrderBy(x => x.Name).ToList();
            ApplicationUtilities.updateListControl(roleDDL, groupRoles, "Id", "Name");
          //  roleDDL.DataSource = groupRoleManager.Roles.ToList().Select(x => x.Name);
           // roleDDL.DataBind();
        }
    }
    private void refreshUserDDList()
    {

       /* roleGroupList.Items.Clear();
        List<ApplicationGroup> groups = groupMgr.Groups.ToList().OrderBy(x => x.Name).ToList();
        ApplicationGroup plzSelectItem = new ApplicationGroup("Plz select");
        plzSelectItem.Id = "";
        groups.Insert(0, plzSelectItem);
        ApplicationUtilities.updateListControl(roleGroupList, groups, "Id", "Name");*/


       // ApplicationUser appuser = new ApplicationUser("allo");
      //  appuser.
         //   appU
        List<ApplicationUser> userList = context.Users.ToList();
        userList.Insert(0, new ApplicationUser("Select a user"));
        ApplicationUtilities.updateListControl(userDDList, context.Users.ToList(), "Id", "UserName");
        //userDDList.DataSource = context.Users.ToList().Select(x => x.UserName);
        //userDDList.DataBind();
        //userDDList.Items.Insert(0, "Select a user");
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
        if (context.Users.ToList().Count == 0 || getSelectedUser() == null)
        {
            userDiv.Visible = false;
            return;
        }
        
            userDiv.Visible = true;
        
        
      
        List<ApplicationUser> users = context.Users.ToList();
        ApplicationUser selectedUser = getSelectedUser();
        if (selectedUser == null)
        {
                selectedUser = context.Users.ToList().First();
        }
       
            userName.Text = selectedUser.UserName;


        /* for (int i = 0; i < users.Count; i++)
         {

             if (users.ElementAt(i).UserName.Equals(userDDList.SelectedValue))
             {
                 selectedUser = users.ElementAt(i);
             }
         }*/

        try
        {
            roleDDL.SelectedValue = groupRoleManager.GetUserGroupRoles(selectedUser.Id).First().ApplicationRoleId;
        }
        catch (Exception ex)
        {
           // Swallow for now
        }


       // IdentityRole previousUserRole = groupRoleManager.FindById(selectedUser.Roles.First().RoleId);
      //  roleDDL.SelectedIndex = roleDDL.Items.IndexOf(roleDDL.Items.FindByValue(previousUserRole.Name));
        
        
        //selectedUser.Roles.ToList().IndexOf(previousUserRole);


    }

    private void updateUserFields()
    {

    }

    private ApplicationUser getSelectedUser()
    {
        if (userDDList.SelectedIndex == -1)
        {
            return null;
        }
        else
        {
            return userManager.FindById(userDDList.SelectedValue);
        }
        /*List<ApplicationUser> users = context.Users.ToList();
        ApplicationUser selectedUser = null;
        for (int i = 0; i < users.Count; i++)
        {

            if (users.ElementAt(i).UserName.Equals(userDDList.SelectedValue))
            {
                selectedUser = users.ElementAt(i);
            }
        }
        return selectedUser;*/
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
    private void showErrorUserNotFound()
    {

    }

    protected void changePasswordButton_Click(object sender, EventArgs e)
    {
        passwordResetDiv.Visible = false;
        //passwordResetResultMessage.Text = "Password reset sucessfully";
        //passwordResetResultMessage.CssClass = "text-"
        ApplicationUser user = getSelectedUser();
        if (user == null)
        {
            userDeletedError.Visible = true;//.CssClass = "text-danger";
            userDeletedError.Text = "User deletion failed. The user could not be found";
            return;
        }
        UserStore<ApplicationUser> store = new UserStore<ApplicationUser>();

        String hashedPassword = userManager.PasswordHasher.HashPassword(Password.Text);
        store.SetPasswordHashAsync(user, hashedPassword);



        userManager.Update(user);
        passwordResetsuccess.Visible = true;


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        // Create a RoleStore object by using the ApplicationDbContext object. 
        // The RoleStore is only allowed to contain IdentityRole objects.
      //  var roleStore = new RoleStore<IdentityRole>(context);

        // Create a RoleManager object that is only allowed to contain IdentityRole objects.
        // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
        //var roleMgr = new RoleManager<IdentityRole>(roleStore);

        //List<IdentityRole> roles = roleManager.Roles.ToList();
        ApplicationUser user = getSelectedUser();
        if (user == null)
        {
            userDeletedError.Visible = true;//.CssClass = "text-danger";
            userDeletedError.Text = "User deletion failed. The user could not be found";
            return;
        }

        List<ApplicationGroup> groupRoles = groupRoleManager.Groups.ToList();
        
        ApplicationGroupRole groupRole = new ApplicationGroupRole();
        ApplicationGroup previousGroupRole = null;
        
        foreach (ApplicationGroup group in groupRoles)
        {
            foreach(ApplicationUserGroup userGroup2 in group.ApplicationUsers)
            {
                if (userGroup2.ApplicationUserId.Equals(user.Id))
                {
                    previousGroupRole = group;
                    break;
                }
            }
            if (previousGroupRole != null)
            {
                break;
            }

        }
        ApplicationUserGroup userGroup = previousGroupRole.ApplicationUsers.First(x => x.ApplicationUserId.Equals(user.Id));
        previousGroupRole.ApplicationUsers.Remove(userGroup);
      IdentityResult result = groupRoleManager.UpdateGroup(previousGroupRole);

        if (result.Succeeded)
        {
        ApplicationGroup currentGroupRole = groupRoleManager.Groups.ToList().Find(X => X.Id.Equals(roleDDL.SelectedValue));
        ApplicationUserGroup tmp = new ApplicationUserGroup();
        tmp.ApplicationGroupId = currentGroupRole.Id;
        tmp.ApplicationUserId = roleDDL.SelectedValue;
        currentGroupRole.ApplicationUsers.Add(tmp);
        
        result = groupRoleManager.UpdateGroup(currentGroupRole);
        }
        else
        {
            
                UserModificationError.Visible = true;
                UserModificationError.Text = "Could not modify the user " + result.Errors.FirstOrDefault();
                return;
            
        }

        if (!result.Succeeded)
        {

            // undo the remove role since the operation failed
            previousGroupRole.ApplicationUsers.Add(userGroup);
            UserModificationError.Visible = true;
            UserModificationError.Text = "Could not modify the user " + result.Errors.FirstOrDefault();
        }

        UserModificationSuccess.Visible = true;
    }

    protected void deleteUser_Click(object sender, EventArgs e)
    {
        ApplicationUser user = getSelectedUser();
        if (user == null)
        {
            userDeletedError.Visible = true;//.CssClass = "text-danger";
            userDeletedError.Text = "User deletion failed. The user could not be found";
            return;
        }


        ApplicationGroupRole groupRole = new ApplicationGroupRole();
        ApplicationGroup userAppGroup = null;

        List<ApplicationGroup> groupRoles = groupRoleManager.Groups.ToList();
        foreach (ApplicationGroup group in groupRoles)
        {
            foreach (ApplicationUserGroup ug in group.ApplicationUsers)
            {
                if (ug.ApplicationUserId.Equals(user.Id))
                {
                    userAppGroup = group;
                    break;
                }
            }
            if (userAppGroup != null)
            {
                break;
            }

        }
        ApplicationUserGroup userGroup = userAppGroup.ApplicationUsers.First(x => x.ApplicationUserId.Equals(user.Id));
        userAppGroup.ApplicationUsers.Remove(userGroup);
        IdentityResult result = groupRoleManager.UpdateGroup(userAppGroup);

        if (result.Succeeded)
        {
            refreshUserDDList();
            userDeletedSuccess.Visible = true;// "User successfully deleted";
            
        }
        else
        {
            userDeletedError.Visible = true;//.CssClass = "text-danger";
            userDeletedError.Text = "User deletion failed with " + result.Errors.FirstOrDefault();
        }
    }
}