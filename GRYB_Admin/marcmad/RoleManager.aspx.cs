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
    RoleManager<IdentityRole> roleMgr;
    ApplicationGroupManager groupMgr;
    protected void Page_Load(object sender, EventArgs e)
    {
        //AddUserAndRole();
        GRYB_Admin.ApplicationDbContext context = new GRYB_Admin.ApplicationDbContext();
        groupMgr = new ApplicationGroupManager();
        // Create a RoleStore object by using the ApplicationDbContext object. 
        // The RoleStore is only allowed to contain IdentityRole objects.
        var roleStore = new RoleStore<IdentityRole>(context);

        // Create a RoleManager object that is only allowed to contain IdentityRole objects.
        // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
        roleMgr = new RoleManager<IdentityRole>(roleStore);


        if (!IsPostBack)
        {

          //  updatePermissionBox();
            updateRoleGroupList();
        }
        
        //var signinManager = Context.GetOwinContext().GetUserManager<ApplicationRoleManager>();
        /*  ListViewItem item = new ListViewItem(ListViewItemType.InsertItem);
          item.ID = "roleId";
          if (!Roles.RoleExists(newRoleName))
              // Create the role
              Roles.CreateRole(newRoleName);
          //roles.datas
          RoleManager.roles();*/
        //roles.ItemTemplate
        
        
        
       // Microsoft.AspNet.Identity.IRoleStore
        //Microsoft.AspNet.Identity.RoleManager

        // roles.Items.Add(item);
    }

    protected void addRole_Click(object sender, EventArgs e)
    {
        /*List<String> existingRoles = roleMgr.Roles.Select(x => x.Name).ToList();


        string newRoleName = addRoleBox.Text;
        
        if (!string.IsNullOrWhiteSpace(newRoleName) && !existingRoles.Contains(newRoleName))
        {
            roleMgr.Create(new IdentityRole { Name = newRoleName });
            updateRoleBox();
        }*/
        // TODO create group and update permission and current permmission list
        string newRoleFroupName = addRoleGroupBox.Text;
        List<String> existingRoleGroups = groupMgr.Groups.Select(x => x.Name).ToList();




        if (!string.IsNullOrWhiteSpace(newRoleFroupName) && !existingRoleGroups.Contains(newRoleFroupName))
        {
            ApplicationGroup newGroup = new ApplicationGroup(newRoleFroupName);
            groupMgr.CreateGroup(newGroup);
            updateRoleGroupList();
            roleGroupList.SelectedValue = newGroup.Id;//roleGroupList.Items.FindByValue(newRoleFroupName);
        }

      

    }

    private void updateRoleGroupList()
    {
        // List<ApplicationGroup> groups = groupMgr.Groups.ToList();
        //roleGroupList.DataValueField = "Id";
        roleGroupList.Items.Clear();
        List<ApplicationGroup> groups = groupMgr.Groups.ToList().OrderBy(x => x.Name).ToList();
        ApplicationGroup plzSelectItem = new ApplicationGroup("Plz select");
        plzSelectItem.Id = "";
        groups.Insert(0, plzSelectItem);      
        ApplicationUtilities.updateListControl(roleGroupList, groups, "Id", "Name");
        updatePermissionBox();
       // roleGroupList.DataTextField = "Name";
      //  roleGroupList.DataTextField = groupMgr.Groups;
           // groups.Select(x => x.Name).ToList();
       // roleGroupList.DataSource = groupMgr.Groups;
       // roleGroupList.DataSourceID = groupMgr.Groups.Select(x => x.Id).ToList();
       // roleGroupList.DataBind();
    }

    protected void removeRole_Click(object sender, EventArgs e)
    {
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
                updateRoleGroupList();
            }
        }
    }

    public void Delete(string id)
    {
        
        if (id == null)
        {
            return;
        }
        
       // var role = await RoleManager.FindByIdAsync(id);
       // if (role == null)
      //  {
      //      return;
       // }
        return;
    }

    private void updatePermissionBox()
    {
        //rolesBox.DataSource = roleMgr.Roles.Select(x => x.Name).ToList();
        //rolesBox.DataBind();
        //rolesBox.DataSource = groupMgr.Groups.Select(x => x.Name).ToList();
        //rolesBox.DataBind();
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
        //ApplicationUtilities.updateListControl(allpermissionBox, allPermissions, "Id", "Name");
        

        //roleGroupList.DataSource = groupMgr.Groups.ToList().OrderBy(x => x.Name); ;
        //roleGroupList.DataBind();

    }


    protected void roles_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void addPermission_Click(object sender, EventArgs e)
    {
        // ApplicationGroup roleGrooup = new ApplicationGroup();

        //ApplicationGroupManager groupmanager = new ApplicationGroupManager();
        //ApplicationGroup group = new ApplicationGroup("test role");
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
        //IdentityRole permissionToAdd = allpermissionBox.SelectedItem;

      //  group.ApplicationRoles.add(new ApplicationGroupRole());

      //  groupmanager.CreateGroup(group);
       // groupmanager.
    }

    protected void removePermission_Click(object sender, EventArgs e)
    {

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
        if (String.IsNullOrWhiteSpace(roleGroupList.SelectedValue))
        {
            permissionDiv.Visible = false;
        }
        else
        {
            permissionDiv.Visible = true;
        }
            updatePermissionBox();
    }
}