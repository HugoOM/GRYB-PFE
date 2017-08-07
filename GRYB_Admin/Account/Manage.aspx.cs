using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using GRYB_Admin;

public partial class Account_Manage : System.Web.UI.Page
{
    protected string SuccessMessage
    {
        get;
        private set;
    }
    private User GetUser()
    {
        IdentityManager manager = new IdentityManager();
      return manager.GetUser(User.Identity.Name);
    }

    private bool HasPassword()
    {
        User user = GetUser();
        return (user != null && user.passwordHash != null);
    }

    protected void Page_Load()
    {
        if (!IsPostBack)
        {
            // Determine the sections to render
            if (HasPassword())
            {
                changePasswordHolder.Visible = true;
            }

            // Render success message
            var message = Request.QueryString["m"];
            if (message != null)
            {
                // Strip the query string from action
                Form.Action = ResolveUrl("~/Account/Manage");

                SuccessMessage =
                    message == "ChangePwdSuccess" ? Resources.General.PasswordChangedSuccessfully
                    : String.Empty;
                successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
            }
        }
    }

    protected void ChangePassword_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            IdentityManager  identityManager= new IdentityManager();
            User user = GetUser();
            IdentityResult result = identityManager.ChangePassword(user.name, CurrentPassword.Text, NewPassword.Text);
            if (result.Succeeded)
            {
                IdentityHelper.SignIn(identityManager, user, isPersistent: false);
                Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
            }
            else
            {
                AddErrors(result);
            }
        }
    }

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error);
        }
    }
}