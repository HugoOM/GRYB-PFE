using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Class for methods that will be used throughout the application
/// </summary>
public static class ApplicationUtilities
{
    public static void updateListControl<T>(ListControl control, List<T> fieldElements, String idField, String textValue)
    {
        control.DataSource = fieldElements;
        control.DataTextField = textValue;
        control.DataValueField = idField;
        
        control.DataBind();
    }
}