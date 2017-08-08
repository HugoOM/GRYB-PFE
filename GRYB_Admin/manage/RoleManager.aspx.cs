using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class MemberPages_UserAndRoleManager : System.Web.UI.Page
{
    string localization;
    protected void Page_Load(object sender, EventArgs e)
    {
        localization = System.Globalization.CultureInfo.CurrentCulture.Parent.ToString();
        updatePermissionDiv();
        if (!IsPostBack)
        {
            updateRoleList(null);
        }
    }

    private void updatePermissionDiv()
    {
        if (String.IsNullOrWhiteSpace(roleList.SelectedValue))
        {
            permissionDiv.Visible = false;
        }
        else
        {
            permissionDiv.Visible = true;
        }
    }

    protected void addRole_Click(object sender, EventArgs e)
    {
        Role role = new Role();
        role.name = addRoleBox.Text;
        List<Permission> permissions = new List<Permission>();
        if (String.IsNullOrEmpty(addRoleBox.Text))
        {
            return;
        }
        foreach (ListItem item in permissionForRole.Items)
        {
            Permission p = new Permission();
            p.id = item.Value;
            permissions.Add(p);
        }
        role.permissions = permissions;

       IdentityResult result = new IdentityManager().CreateRole(role);

        if (result.Succeeded)
        {
            addRoleSuccess.Visible = true;
            IdentityManager manager = new IdentityManager(localization);
            updateRoleList(manager.GetRoleByName(role.name));
            updatePermissionDiv();

        }
        else
        {
            addRoleFailure.Text = result.Errors.FirstOrDefault();
            addRoleFailure.Visible = true;
        }


        }

    private void updateRoleList(Role role)
    {
        roleList.Items.Clear();
        List<Role> orderedRoles = new IdentityManager().GetRoles().OrderBy(i => i.name).ToList();
        Role plzSelectItem = new Role();
        plzSelectItem.name = Resources.General.PleaseSelectARole;
        orderedRoles.Insert(0, plzSelectItem);
        ApplicationUtilities.updateListControl(roleList, orderedRoles, "id", "name");

        if (role != null && role.id != null)
        {
            roleList.SelectedIndex = roleList.Items.IndexOf(roleList.Items.FindByValue(role.id));
        }
        updatePermissionBox();
    }

    protected void removeRole_Click(object sender, EventArgs e)
    {
        IdentityManager manager = new IdentityManager();
        if (String.IsNullOrEmpty(roleList.SelectedValue))
        {
            return;
        }
        Role role = manager.GetRole(roleList.SelectedValue);
       IdentityResult result = manager.DeleteRole(role);
        if (!result.Succeeded)
        {
            addRoleFailure.Text = result.Errors.FirstOrDefault();
            addRoleFailure.Visible = true;
        }
        updateRoleList(role);
        updatePermissionDiv();
            
        
    }

    private void updatePermissionBox()
    {
        allpermissionBox.Items.Clear();
        permissionForRole.Items.Clear();
        IdentityManager manager = new IdentityManager(localization);
        // Load all permissions on the allPermissionbox if it can't find the role.
        if (String.IsNullOrEmpty(roleList.SelectedValue))
        {
                ApplicationUtilities.updateListControl(allpermissionBox, manager.GetPermissions().OrderBy(i => i.localizedName).ToList(), "id", "localizedName");
        }
        else
        {
            List<Permission> allPermissions = manager.GetPermissions().OrderBy(i => i.localizedName).ToList();
            List<Permission> permissionForRole = manager.GetPermissions(roleList.SelectedValue).OrderBy(i => i.localizedName).ToList();

            foreach (Permission p in permissionForRole)
            {
                allPermissions.RemoveAll(i => i.id == p.id);
            }
            ApplicationUtilities.updateListControl(allpermissionBox, allPermissions, "id", "localizedName");
            ApplicationUtilities.updateListControl(this.permissionForRole, permissionForRole, "id", "localizedName");
        }

    }

    protected void addPermission_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(roleList.SelectedValue) || String.IsNullOrEmpty(allpermissionBox.SelectedValue))
        {
            return;
        }

        IdentityManager manager = new IdentityManager(localization);
        manager.AddRolePermission(roleList.SelectedValue, allpermissionBox.SelectedValue);
        updatePermissionBox();
    }

    protected void removePermission_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(roleList.SelectedValue) || String.IsNullOrEmpty(permissionForRole.SelectedValue))
        {
            return;
        }

        IdentityManager manager = new IdentityManager(localization);
        manager.DeleteRolePermission(roleList.SelectedValue, permissionForRole.SelectedValue);
        updatePermissionBox();

    }

    protected void roleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        updatePermissionBox();
        updatePermissionDiv();
    }
}