using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Represent the permissions in the database
/// </summary>
public static class RolePermission

{
    public const string addUser = "addUser";
    public const string manageUser = "manageUser";
    public const string manageRole = "manageRole";
    public const string removeUser = "removeUser"; // Unused/not fonctionnal as of now
    public const string manageAttachment = "manageAttachment";
    public const string manageMachine = "manageMachine";
    public const string manageProject = "manageProject";
}