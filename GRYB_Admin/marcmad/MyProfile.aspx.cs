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
  /*  protected void Page_Load(object sender, EventArgs e)
    {
        AddUserAndRole();
        if (!IsPostBack)
        {
            updateRoleBox();
        }
        

        
        
        
       // Microsoft.AspNet.Identity.IRoleStore
        //Microsoft.AspNet.Identity.RoleManager

        // roles.Items.Add(item);
    }

    protected void addRole_Click(object sender, EventArgs e)
    {
        List<String> existingRoles = roleMgr.Roles.Select(x => x.Name).ToList();


        string newRoleName = addRoleBox.Text;
        
        if (!string.IsNullOrWhiteSpace(newRoleName) && !existingRoles.Contains(newRoleName))
        {
            roleMgr.Create(new IdentityRole { Name = newRoleName });
            updateRoleBox();
        }
       // ListViewItem item = new ListViewItem(ListViewItemType.InsertItem);
        //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

    }

    protected void removeRole_Click(object sender, EventArgs e)
    {
        // TODO vérifier s'il y a des utilisateurs associés à un role. Offrir un warning avant de supprimer
         String roleToDelete = rolesBox.SelectedValue;
        if (string.IsNullOrWhiteSpace(roleToDelete))
        {
            return;
        }

        List<IdentityRole> roles = roleMgr.Roles.ToList();
        foreach (IdentityRole role in roles)
        {
            if (role.Name.Equals(roleToDelete))
            {
                roleMgr.Delete(role);
                updateRoleBox();
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

    private void updateRoleBox()
    {
        rolesBox.DataSource = roleMgr.Roles.Select(x => x.Name).ToList();
        rolesBox.DataBind();
    }


    protected void roles_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void AddUserAndRole()
    {
        // Access the application context and create result variables.
        GRYB_Admin.ApplicationDbContext context = new GRYB_Admin.ApplicationDbContext();
        IdentityResult IdRoleResult;
        IdentityResult IdUserResult;

        // Create a RoleStore object by using the ApplicationDbContext object. 
        // The RoleStore is only allowed to contain IdentityRole objects.
        var roleStore = new RoleStore<IdentityRole>(context);

        // Create a RoleManager object that is only allowed to contain IdentityRole objects.
        // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
        roleMgr = new RoleManager<IdentityRole>(roleStore);
        
        // Then, you create the "canEdit" role if it doesn't already exist.

        if (!roleMgr.RoleExists("canEdit"))
        {
            IdRoleResult = roleMgr.Create(new IdentityRole { Name = "canEdit" });
        }

        // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
        // object. Note that you can create new objects and use them as parameters in
        // a single line of code, rather than using multiple lines of code, as you did
        // for the RoleManager object.
        var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        var appUser = new ApplicationUser
        {
            UserName = "canEditUser@wingtiptoys.com",
            Email = "canEditUser@wingtiptoys.com"
        };
        IdUserResult = userMgr.Create(appUser, "Pa$$word1");

        // If the new "canEdit" user was successfully created, 
        // add the "canEdit" user to the "canEdit" role. 
        if (!userMgr.IsInRole(userMgr.FindByEmail("canEditUser@wingtiptoys.com").Id, "canEdit"))
        {
            IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("canEditUser@wingtiptoys.com").Id, "canEdit");
        }

    }*/
}