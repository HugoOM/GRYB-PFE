using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using GRYB_Admin;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LogIn(object sender, EventArgs e)
        {
        // La page est valide
        if (IsValid)
            {
            IdentityManager manager = new IdentityManager();
            User user = manager.Login(UserName.Text, Password.Text);
                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                FailureText.Text = Resources.General.InvalidUserNameOrPassword;
                ErrorMessage.Visible = true;
                }
            }
        }
}