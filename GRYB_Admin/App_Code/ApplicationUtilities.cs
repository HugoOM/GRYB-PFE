using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Class containing utilities methods used throughout the application
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

    // Get the locales supported by the application.
    public static List<String> getSupportedLocale()
    {
        return new List<string> { "en", "fr" };
    }
}