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
    /// <summary>
    /// Update a list control that organize their data in a list like a dropDownList. 
    /// As an example, if you pass a list of Person which has an id and a name, you can pass the parameter "id" and "name".
    /// It will fetch them from the class on runtime.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="control">The control to upgate</param>
    /// <param name="fieldElements">The elements to update the control with</param>
    /// <param name="idField">Key to access the unique identifier to each element, will be the value</param>
    /// <param name="textValue">Key to access the text that will represent the element</param>
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