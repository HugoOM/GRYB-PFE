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
using System.Security.Claims;

public partial class MemberPages_UserAndRoleManager : System.Web.UI.Page
{
    //RoleManager<IdentityRole> roleMgr;
   // ApplicationGroupManager groupMgr;
    protected void Page_Load(object sender, EventArgs e)
    {
        // ApplicationDbContext context = new ApplicationDbContext();
        // groupMgr = new ApplicationGroupManager();
        // var roleStore = new RoleStore<IdentityRole>(context);
       //  roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));


        if (!IsPostBack)
        {
            updateRoleGroupList(new ApplicationGroupManager());
        }
    }

    private void updatePermissionDiv()
    {
        if (String.IsNullOrWhiteSpace(roleGroupList.SelectedValue))
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
        ApplicationGroupManager groupMgr = new ApplicationGroupManager();
        string newRoleFroupName = addRoleGroupBox.Text;
        List<String> existingRoleGroups = groupMgr.Groups.Select(x => x.Name).ToList();


        if (existingRoleGroups.Contains(newRoleFroupName))
        {
            addRoleFailure.Text = "The role " + newRoleFroupName + " could not be added: role already exist";
            addRoleFailure.Visible = true;
        }

        if (!string.IsNullOrWhiteSpace(newRoleFroupName) && !existingRoleGroups.Contains(newRoleFroupName))
        {
            ApplicationGroup newGroup = new ApplicationGroup(newRoleFroupName);
          IdentityResult result = groupMgr.CreateGroup(newGroup);
            if (result.Succeeded)
            {
                addRoleSuccess.Visible = true;
            }
            else
            {
                addRoleFailure.Text = "The role " + newRoleFroupName + " could not be added: " + result.Errors.FirstOrDefault();
                addRoleFailure.Visible = true;
            }
            updateRoleGroupList(groupMgr);
            updatePermissionDiv();
        }

      

    }

    private void updateRoleGroupList(ApplicationGroupManager groupMgr)
    {
        roleGroupList.Items.Clear();
        List<ApplicationGroup> groups = groupMgr.Groups.ToList().OrderBy(x => x.Name).ToList();
        ApplicationGroup plzSelectItem = new ApplicationGroup("Plz select");
        plzSelectItem.Id = "";
        groups.Insert(0, plzSelectItem);      
        ApplicationUtilities.updateListControl(roleGroupList, groups, "Id", "Name");
        updatePermissionBox(groupMgr, new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())));
    }

    protected void removeRole_Click(object sender, EventArgs e)
    {
        ApplicationGroupManager groupMgr = new ApplicationGroupManager();
        // TODO vérifier s'il y a des utilisateurs associés à un role. Offrir un warning avant de supprimer
        String idGroupToDelete = roleGroupList.SelectedValue;
        if (string.IsNullOrWhiteSpace(idGroupToDelete))
        {
            return;
        }
        List<ApplicationGroup> roleGroups = groupMgr.Groups.ToList();
       // List<IdentityRole> roles = roleMgr.Roles.ToList();
        foreach (ApplicationGroup roleGroup in roleGroups)
        {
            if (roleGroup.Id.Equals(idGroupToDelete))
            {
                groupMgr.DeleteGroup(roleGroup.Id);
                //TODO maybe dans le delete mettre les utilisateurs qui avaient ce groupe a un groupe par défaut eg: user sams droit ou créer le groupe user au démarrage de l'app et assigner les users sans groupes ou rien faire
                updateRoleGroupList(groupMgr);
                updatePermissionDiv();
            }
        }
    }

    private void updatePermissionBox(ApplicationGroupManager groupMgr, RoleManager<IdentityRole> roleMgr)
    {
        //ApplicationGroupManager groupMgr = new ApplicationGroupManager();
        string groupRoleId = roleGroupList.SelectedValue;
        ApplicationGroup currentGroupRole = groupMgr.Groups.ToList().Find(X => X.Id.Equals(groupRoleId));
        
        List <IdentityRole> allPermissions = roleMgr.Roles.ToList();
        List<IdentityRole> Permissions = new List<IdentityRole>();
        if (currentGroupRole != null)
        {
            List<string> roleIds = currentGroupRole.ApplicationRoles.Select(x => x.ApplicationRoleId).ToList();
            
            foreach (string roleid in roleIds)
            {
                IdentityRole permission = allPermissions.Find(x => x.Id.Equals(roleid));
                Permissions.Add(permission);
                allPermissions.Remove(permission);
            }
        }
        
        ApplicationUtilities.updateListControl(permissionBox, Permissions, "Id", "Name");
        ApplicationUtilities.updateListControl(allpermissionBox, allPermissions, "Id", "Name");

    }

    protected void addPermission_Click(object sender, EventArgs e)
    {
        ApplicationGroupManager groupMgr = new ApplicationGroupManager();
        ApplicationGroup currentGroupRole = groupMgr.Groups.ToList().Find(X => X.Id.Equals(roleGroupList.SelectedValue));
        if (allpermissionBox.SelectedIndex == -1 || String.IsNullOrWhiteSpace(currentGroupRole.Id))
        {
            return;
        }

        ApplicationGroupRole groupRole = new ApplicationGroupRole();
        groupRole.ApplicationGroupId = currentGroupRole.Id;
        groupRole.ApplicationRoleId = allpermissionBox.SelectedValue;
        currentGroupRole.ApplicationRoles.Add(groupRole);
        groupMgr.UpdateGroup(currentGroupRole);
        
        permissionBox.Items.Add(allpermissionBox.SelectedItem);
        allpermissionBox.Items.Remove(allpermissionBox.SelectedItem);
        permissionBox.ClearSelection();
        allpermissionBox.ClearSelection();
    }

    protected void removePermission_Click(object sender, EventArgs e)
    {
        ApplicationGroupManager groupMgr = new ApplicationGroupManager();
        ApplicationGroup currentGroupRole = groupMgr.Groups.ToList().Find(X => X.Id.Equals(roleGroupList.SelectedValue));
        if (permissionBox.SelectedIndex == -1 || String.IsNullOrWhiteSpace(currentGroupRole.Id))
        {
            return;
        }


        ApplicationGroupRole groupRole = currentGroupRole.ApplicationRoles.First
            (x => x.ApplicationGroupId.Equals(currentGroupRole.Id) && 
             x.ApplicationRoleId.Equals(permissionBox.SelectedValue));
        currentGroupRole.ApplicationRoles.Remove(groupRole);
        
        groupMgr.UpdateGroup(currentGroupRole);
        

        allpermissionBox.Items.Add(permissionBox.SelectedItem);
        permissionBox.Items.Remove(permissionBox.SelectedItem);
        permissionBox.ClearSelection();
        allpermissionBox.ClearSelection();

    }

    protected void roleGroupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        updatePermissionBox(new ApplicationGroupManager(), new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())));
        updatePermissionDiv();
    }
}