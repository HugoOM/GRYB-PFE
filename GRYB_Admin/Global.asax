<%@ Application Language="C#" %>
<%@ Import Namespace="GRYB_Admin" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        // Create the custom role and user.
          //RoleActions roleActions = new RoleActions();
          //roleActions.AddUserAndRole();
    }

</script>
