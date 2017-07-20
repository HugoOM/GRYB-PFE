using GRYB_Admin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for IdentityConfig
/// </summary>


    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }


    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }

    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
        }

    public static implicit operator ApplicationRoleManager(RoleManager<IdentityRole> v)
    {
        throw new NotImplementedException();
    }
}

// TODO for dev, put DropCreateDatabaseAlways to recreate the db always. When in prod, replace with DropCreateDatabaseIfModelChanges
public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
{
    protected override void Seed(ApplicationDbContext context)
    {
        InitializeIdentityForEF(context);
        base.Seed(context);
    }
    public static void InitializeIdentityForEF(ApplicationDbContext db)
    {

      //  _db = new ApplicationDbContext();
       // var userStore = new UserStore<ApplicationUser>(_db);
       // _userManager = new UserManager<ApplicationUser>(userStore);
       // _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));

      //  var roleStore = new RoleStore<ApplicationRole>(_db);
       // _roleManager = new RoleManager<ApplicationRole>(roleStore);

        //_db = new ApplicationDbContext(conText);
        /*_db = HttpContext.Current
            .GetOwinContext().Get<ApplicationDbContext>();
       /* _userManager = HttpContext.Current
            .GetOwinContext().GetUserManager<ApplicationUserManager>();
        _roleManager = HttpContext.Current
            .GetOwinContext().Get<ApplicationRoleManager>();*/
       // _groupStore = new ApplicationGroupStore(_db);


        var roleStore = new RoleStore<IdentityRole>(db);
        var userStore = new UserStore<ApplicationUser>(db);
       // _userManager = new UserManager<ApplicationUser>(userStore);

        // Create a RoleManager object that is only allowed to contain IdentityRole objects.
        // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
     //   roleMgr = new RoleManager<IdentityRole>(roleStore);
        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

        const string name = "admin@example.com";
        const string password = "Admin@123456";
        const string roleName = "Admin";
        List<string> permissions = new List<string>{ "EditUser", "ViewUser" };

        foreach (String permissionName in permissions)
        {
            if (roleManager.FindByName(permissionName) == null)
            {
                roleManager.Create(new ApplicationRole(permissionName));
            }
        }

        //Create Role Admin if it does not exist
        var role = roleManager.FindByName(roleName);
        if (role == null)
        {
            role = new ApplicationRole(roleName);
            var roleresult = roleManager.Create(role);
        }

        var user = userManager.FindByName(name);
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = name,
                Email = name,
                EmailConfirmed = true
            };

            var result = userManager.Create(user, password);
            result = userManager.SetLockoutEnabled(user.Id, false);
        }

        var groupManager = new ApplicationGroupManager();
        var newGroup = new ApplicationGroup("SuperAdmins", "Full Access to All");

        groupManager.CreateGroup(newGroup);
     //   groupManager.SetUserGroups(user.Id, new string[] { newGroup.Id });
        groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });
    }
}

    /*   public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
       {
           public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
               base(userManager, authenticationManager)
           { }

           public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
           {
               return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
           }

           public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
           {
               return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
           }
       }*/
