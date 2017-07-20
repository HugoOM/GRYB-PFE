using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ApplicationUtilities
/// </summary>
public class ApplicationUtilities
{
    public ApplicationUtilities()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void updateListControl<T>(ListControl control, List<T> fieldElements, String idField, String textValue)
    {
        control.DataSource = fieldElements;
        control.DataTextField = textValue;
        control.DataValueField = idField;
        
        control.DataBind();
    }
}