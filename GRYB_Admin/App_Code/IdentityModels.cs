using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System;
using System.Collections.Generic;

namespace GRYB_Admin
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public static void SignIn(IdentityManager manager, User user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.name, ClaimValueTypes.String, user.id));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.id));
            List<Permission> permissions = user.role.permissions;
            foreach (Permission p in permissions)
            {
                claims.Add(new Claim(ClaimTypes.Role, p.code, ClaimValueTypes.String, p.id));
            }
            
            var userIdentity = new ClaimsIdentity("ApplicationCookie");
            
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, userIdentity);
        }

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request[ProviderNameKey];
        }

        public static string GetExternalLoginRedirectUrl(string accountProvider)
        {
            return "/Account/RegisterExternalLogin?" + ProviderNameKey + "=" + accountProvider;
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}