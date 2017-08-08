using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Http;

[Authorize(Roles = RolePermission.removeUser)]
public partial class MemberPages_UserAndRoleManager : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        hideAllActionMessages();
        if (!IsPostBack)
        {
            refreshFields(null);
        }
    }

    private void refreshFields(string userId)
    {
        userDDList.Items.Clear();
        IdentityManager manager = new IdentityManager();
        User plzSelectItem = new User();
        plzSelectItem.name = Resources.General.PleaseSelectAUser;
        List<User> orderedUsers = manager.GetUsers().OrderBy(i => i.name).ToList();
        orderedUsers.Insert(0, plzSelectItem);
        ApplicationUtilities.updateListControl(userDDList, orderedUsers, "id", "name");
        ApplicationUtilities.updateListControl(roleDDL, manager.GetRoles().OrderBy(i => i.name).ToList(), "id", "name");

        if (!String.IsNullOrEmpty(userId))
        {
            userDDList.SelectedIndex = userDDList.Items.IndexOf(userDDList.Items.FindByValue(userId));
            userName.Text = userDDList.SelectedItem.Text;
            Role role = manager.GetUser(userDDList.SelectedItem.Text).role;
            if (role != null)
            {
                roleDDL.SelectedIndex = roleDDL.Items.IndexOf(roleDDL.Items.FindByValue(role.id));
            }
            userDiv.Visible = true;
        }
        else
        {
            userDiv.Visible = false;
        }
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
        refreshFields(userDDList.SelectedValue);
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
        if (String.IsNullOrEmpty(userDDList.SelectedValue))
        {
            return;
        }
        IdentityManager manager = new IdentityManager();
        User user = manager.GetUser(userDDList.SelectedItem.Text);
        user.setPasswordHash(Password.Text, false);
      int result = manager.UpdateUser(user);
        if (result == 1)
        {
            passwordResetsuccess.Visible = true;
            
        }
        else
        {
            passwordResetError.Text = Resources.General.AnErrorOccured_passwordNotChanged;
            passwordResetError.Visible = true;
        }   
    }
    [Authorize(Roles = RolePermission.manageUser)]
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(userDDList.SelectedValue))
        {
            return;
        }
        IdentityManager manager = new IdentityManager();
        User user = manager.GetUser(userDDList.SelectedItem.Text);
        user.role = manager.GetRole(roleDDL.SelectedValue);
       int result = manager.UpdateUser(user);
        if (result == 1)
        {
            UserModificationSuccess.Visible = true;
        }
        else
        {
            UserModificationError.Visible = true;
            UserModificationError.Text = Resources.General.UserModificationFailed;
        } 
    }

    [Authorize(Roles = RolePermission.removeUser)]
    protected void deleteUser_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(userDDList.SelectedValue))
        {
            return;
        }
        IdentityManager manager = new IdentityManager();
        User user = manager.GetUser(userName.Text);
        if (user == null)
        {
            userDeletedError.Visible = true;
            userDeletedError.Text = Resources.General.UserDeletionFailed_notFound;
            return;
        }

        int result = manager.DeleteUser(user);
        if (result == 1)
        {
            refreshFields(null);
            userDeletedSuccess.Visible = true;// "User successfully deleted";
        }
        else
        {
            userDeletedError.Visible = true;
            userDeletedError.Text = Resources.General.UserDeletionFailedPrefix;
        }
    }
}
 
 