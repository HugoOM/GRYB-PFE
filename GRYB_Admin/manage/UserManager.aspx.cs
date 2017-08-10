using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
        try
        {
            userDDList.Items.Clear();
            IdentityManager manager = new IdentityManager();
            // Append a please select a user item at the beginning of the list
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
                passwordResetDiv.Visible = true;
            }
            else
            {
                userDiv.Visible = false;
                passwordResetDiv.Visible = false;
            }
        }catch (Exception ex)
        {
            userModificationError.Visible = true;
            userModificationErrorAlert.Visible = true;
            userModificationError.Text = Resources.General.AnErrorHasOccured + ex.ToString();
        }
    }

    protected void userDDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        refreshFields(userDDList.SelectedValue);
    }

    private void hideAllActionMessages()
    {
        passwordResetSuccess.Visible = false;
        passwordResetSuccessAlert.Visible = false;
        passwordResetError.Visible = false;
        passwordResetErrorAlert.Visible = false;
        userDeletedSuccess.Visible = false;
        userDeletedSuccessAlert.Visible = false;
        userDeletedError.Visible = false;
        userDeletedErrorAlert.Visible = false;
        userModificationSuccess.Visible = false;
        userModificationSuccessAlert.Visible = false;
        userModificationError.Visible = false;
        userModificationErrorAlert.Visible = false;
    }

    [Authorize(Roles = RolePermission.manageUser)]
    protected void changePasswordButton_Click(object sender, EventArgs e)
    {
        try
        {


            // For the cases where we have no user selected
            if (String.IsNullOrEmpty(userDDList.SelectedValue))
            {
                return;
            }
            IdentityManager manager = new IdentityManager();
            User user = manager.GetUser(userDDList.SelectedItem.Text);
            user.setPasswordHash(Password.Text, false);
            int result = manager.UpdateUser(user);
            // result is the number of line modified, 1 mean it modified the line we wanted
            if (result == 1)
            {
                passwordResetSuccess.Visible = true;
                passwordResetSuccessAlert.Visible = true;
            }
            else
            {
                passwordResetError.Text = Resources.General.AnErrorOccured_passwordNotChanged;
                passwordResetError.Visible = true;
                passwordResetErrorAlert.Visible = true;
            }
        }catch (Exception ex)
        {
            userModificationError.Visible = true;
            userModificationErrorAlert.Visible = true;
            userModificationError.Text = Resources.General.AnErrorHasOccured + ex.ToString();
        }
    }
    [Authorize(Roles = RolePermission.manageUser)]
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {


            // For the cases where we have no user selected
            if (String.IsNullOrEmpty(userDDList.SelectedValue))
            {
                return;
            }
            IdentityManager manager = new IdentityManager();
            User user = manager.GetUser(userDDList.SelectedItem.Text);
            user.role = manager.GetRole(roleDDL.SelectedValue);
            int result = manager.UpdateUser(user);
            // result is the number of line modified, 1 mean it modified the line we wanted
            if (result == 1)
            {
                userModificationSuccess.Visible = true;
                userModificationSuccessAlert.Visible = true;
            }
            else
            {
                userModificationError.Visible = true;
                userModificationErrorAlert.Visible = true;
                userModificationError.Text = Resources.General.UserModificationFailed;
            }
        }catch (Exception ex)
        {
            userModificationError.Visible = true;
            userModificationErrorAlert.Visible = true;
            userModificationError.Text = Resources.General.AnErrorHasOccured + ex.ToString();
        }
    }

    [Authorize(Roles = RolePermission.removeUser)]
    protected void deleteUser_Click(object sender, EventArgs e)
    {
        try
        {


            // For the cases where we have no user selected
            if (String.IsNullOrEmpty(userDDList.SelectedValue))
            {
                return;
            }
            IdentityManager manager = new IdentityManager();
            User user = manager.GetUser(userName.Text);
            if (user == null)
            {
                userDeletedError.Visible = true;
                userDeletedErrorAlert.Visible = true;
                userDeletedError.Text = Resources.General.UserDeletionFailed_notFound;
                return;
            }

            int result = manager.DeleteUser(user);
            // result is the number of line modified, 1 mean it modified the line we wanted
            if (result == 1)
            {
                refreshFields(null);
                userDeletedSuccess.Visible = true;
                userDeletedSuccessAlert.Visible = true;
            }
            else
            {
                userDeletedError.Visible = true;
                userDeletedErrorAlert.Visible = true;
                userDeletedError.Text = Resources.General.UserDeletionFailedPrefix;
            }
        } catch (Exception ex)
        {
            userModificationError.Visible = true;
            userModificationErrorAlert.Visible = true;
            userModificationError.Text = Resources.General.AnErrorHasOccured + ex.ToString();
        }
    }
}
 
 