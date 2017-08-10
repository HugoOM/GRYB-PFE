using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Interface to the database for everything related to Identity. Manage CRUD on users and roles.
/// You can pass a locale string if you want to received localized text from the DB. Otherwise, it use the default locale.
/// To see the locales supported, see ApplicationUtilities.getSupportedLocale() to get a list of supported locales
/// </summary>
public class IdentityManager
{
    private static string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private string locale;
    private string defaultLocale = "en";
    
    public IdentityManager()
    {
    }

    public IdentityManager(string locale)
    {
        if (ApplicationUtilities.getSupportedLocale().Contains(locale))
        {
            this.locale = locale;
        }
        
    }
    /// <summary>
    /// Create a new user. Fail if a user with that name already exist
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public IdentityResult CreateUser(User user)
    {
        if (GetUser(user.name) != null)
        {
            return new IdentityResult(Resources.General.OperationFailed_UsernameAlreadyExist);
        }
        int nbAffectedColumns = 0;
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        try
        {
        NpgsqlCommand command = new NpgsqlCommand();
        conn.Open();
        command.Connection = conn;
        command.CommandText = "INSERT INTO Utilisateur (nom,mot_de_passe, id_role) VALUES (@p1,@p2,@p3)";
        command.Parameters.AddWithValue("p1", user.name);
        command.Parameters.AddWithValue("p2", user.passwordHash);
        command.Parameters.AddWithValue("p3", Convert.ToInt32(user.role.id));
        nbAffectedColumns = command.ExecuteNonQuery();
            
        }
        finally
        {
            conn.Close();
        }
        if (nbAffectedColumns == 0)
        {
            return new IdentityResult(Resources.General.OperationFailed_usersWasNotAdded);
        }
        return IdentityResult.Success; // rien = succès?
    }
    /// <summary>
    /// Remove a user from the database
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public int DeleteUser(User user)
    {

        int nbAffectedColumns = 0;
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        NpgsqlCommand command = new NpgsqlCommand();
        try
        {    
        conn.Open();
        command.Connection = conn;
        command.CommandText = "Delete from Utilisateur where id_utilisateur  = @p1";
        command.Parameters.AddWithValue("p1", Convert.ToInt32(user.id));
        nbAffectedColumns = command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
        return nbAffectedColumns;
    }
    /// <summary>
    /// Get a user based on the username. Will also load the user roles and permissions
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public User GetUser(String username)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        User user = new User();
        try
        {

            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Select id_utilisateur, nom, mot_de_passe, id_role from Utilisateur where nom  = @p1";
            command.Parameters.AddWithValue("p1", username);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                return null;
            }
            reader.Read();
            user.id = reader[0].ToString();
            user.name = reader[1].ToString();
            user.setPasswordHash(reader[2].ToString(), true);
            user.role = GetRole(reader[3].ToString());
        }
        finally
        {
            conn.Close();

        }
        
        return user;
       
    }
    /// <summary>
    /// Get a list of all users, each with their role and permissions
    /// </summary>
    /// <returns></returns>
    public List<User> GetUsers()
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        List<User> users = new List<User>();
        try { 
        
            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Select id_utilisateur, nom, mot_de_passe, id_role from Utilisateur";
            NpgsqlDataReader reader = command.ExecuteReader();
        
            while (reader.Read())
            {
                User user = new User();
                user.id = reader[0].ToString();
                user.name = reader[1].ToString();
                user.setPasswordHash(reader[2].ToString(), true);
                user.role = GetRole(reader[3].ToString());
                users.Add(user);
            }
        }
        finally
        {
            conn.Close();
            
        }
        return users;

    }
    /// <summary>
    /// Check if the user loging credentials are valid, return the user if they are and null otherwise.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="plainPassword">Password that is not hashed</param>
    /// <returns></returns>
    public User Login(String name, String plainPassword)
    {
        User user = GetUser(name);
        if (user == null)
        {
            return null;
        }

        PasswordHasher hasher = new PasswordHasher();
        PasswordVerificationResult result = hasher.VerifyHashedPassword(user.passwordHash, plainPassword);
        if (result.Equals(PasswordVerificationResult.Success))
        {
            return user;
        }
        else if (result.Equals(PasswordVerificationResult.SuccessRehashNeeded))
        {
            user.setPasswordHash(hasher.HashPassword(plainPassword), false);
            UpdateUser(user);
            return user;
        }
        else
        {
            // Failed
            return null;
        }
    }
    /// <summary>
    /// If the user exist and the old password match the current password, it will change the current password for the new password.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="oldPasswordPlain">Current password of the user</param>
    /// <param name="newPasswordPlain">New password for the user</param>
    /// <returns></returns>
    public IdentityResult ChangePassword(string userName, string oldPasswordPlain, string newPasswordPlain)
    {
       string newPassword  = new PasswordHasher().HashPassword(newPasswordPlain);
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        int nbAffectedColumns = 0;
        try
        {

        
        User user = Login(userName, oldPasswordPlain);
        if (user == null)
        {
            return new IdentityResult(Resources.General.OperationFailed_oldPasswordCurrentPasswordMismatch);
        }

        
        NpgsqlCommand command = new NpgsqlCommand();
        conn.Open();
        command.Connection = conn;
        command.CommandText = "Update Utilisateur set mot_de_passe = @p1 where id_utilisateur  = @p2";
        command.Parameters.AddWithValue("p1", newPassword);
        command.Parameters.AddWithValue("p2", Convert.ToInt32(user.id));
        nbAffectedColumns = command.ExecuteNonQuery();
        } 
        finally
        {
            conn.Close();
        }

        if (nbAffectedColumns == 0)
        {
            return new IdentityResult(Resources.General.AnErrorOccured_passwordNotChanged);    
        }
        return IdentityResult.Success;
    }




    /// <summary>
    /// Update the user in the database, including the role he is assigned to, but does not update the role in any way.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public int UpdateUser(User user)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        Role role = user.role;
        int nbAffectedColumns = 0;
        try
        {
        NpgsqlCommand command = new NpgsqlCommand();
        conn.Open();
        command.Connection = conn;
        command.CommandText = "Update Utilisateur set (nom, mot_de_passe,id_role) = (@p1, @p2, @p3) where id_utilisateur  = @p4";
        command.Parameters.AddWithValue("p1", user.name);
        command.Parameters.AddWithValue("p2", user.passwordHash);
        command.Parameters.AddWithValue("p3", Convert.ToInt32(user.role.id));
        command.Parameters.AddWithValue("p4", Convert.ToInt32(user.id));
        nbAffectedColumns = command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
        return nbAffectedColumns;
    }
    /// <summary>
    /// Create a new role and assign the permissions to it. Will fail if a role with the same name already exist
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public IdentityResult CreateRole(Role role)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        if (GetRoleByName(role.name) != null)
        {
            return new IdentityResult(Resources.General.RoleFailurePrefix + " " + role.name + " " + Resources.General.RoleFailureSuffix_alreadyExist);
        }
        try
        {
        NpgsqlCommand command = new NpgsqlCommand();
        conn.Open();
        command.Connection = conn;
        command.CommandText = "INSERT INTO Role (nom) VALUES (@p1)";
        command.Parameters.AddWithValue("p1", role.name);
        int nbAffectedColumns = command.ExecuteNonQuery();
        conn.BeginTransaction();
        if (nbAffectedColumns == 0)
        {
            return new IdentityResult(Resources.General.OperationFailed_roleNotAdded);
        }
        role = GetRoleByName(role.name); // Get the role id

        List<Permission> rolePermissions = role.permissions;
        if (rolePermissions != null)
        {
            foreach (Permission p in rolePermissions)
            {
                AddRolePermission(role.id, p.id);
            }
        }
        
        }
        finally
        {
            conn.Close();
        }
        return IdentityResult.Success;
    }
    /// <summary>
    /// Delete a role and it's associations with permissions
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public IdentityResult DeleteRole(Role role)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        int nbAffectedColumns = 0;
        try
        {
            if (countUserWithRole(role)!= 0)
            {
                return new IdentityResult(Resources.General.OperationFailed_usersWithRoleExist);
            }
        
        NpgsqlCommand command = new NpgsqlCommand();
        DeleteRolePermission(role.id);
        conn.Open();
        command.Connection = conn;
        command.CommandText = "Delete from Role where id_role  = @p1";
        command.Parameters.AddWithValue("p1",Convert.ToInt32(role.id));
        nbAffectedColumns = command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
        
        return IdentityResult.Success;
    }
    /// <summary>
    /// Count the number of users that have the role passed as parameter
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public int countUserWithRole(Role role)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        List<User> users = new List<User>();
        try
        {

            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Select Count(*) from Utilisateur where id_role = @p1";
            command.Parameters.AddWithValue("p1", Convert.ToInt32(role.id));
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return Convert.ToInt32(reader[0]);
            
        }
        finally
        {
            conn.Close();

        }
        

    }
    /// <summary>
    /// Get the role and associated permissions based on the id of a role. Return null if it failed.
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public Role GetRole(string roleId)
    {
        if (roleId == null)
        {
            return null;
        }
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        Role role = new Role();
        try
        {

            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Select id_role, nom from Role where id_role  = @p1";
            command.Parameters.AddWithValue("p1", Convert.ToInt32(roleId));
            NpgsqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                return null;
            }
            reader.Read();
            role.id = reader[0].ToString();
            role.name = reader[1].ToString();
            role.permissions = GetPermissions(role.id);
        }
        finally
        {
            conn.Close();

        }

        return role;

    }
    /// <summary>
    /// Get the role and associated permissions based on the name of a role. Return null if it failed.
    /// </summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public Role GetRoleByName(String roleName)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);

        Role role = new Role();
        try
        {

            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Select id_role, nom from Role where nom  = @p1";
            command.Parameters.AddWithValue("p1", roleName);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                return null;
            }
            reader.Read();
            
            role.id = reader[0].ToString();
            role.name = reader[1].ToString();
            role.permissions = GetPermissions(role.id);
        }
        finally
        {
            conn.Close();

        }
        return role;

    }
    /// <summary>
    /// Get a list of all the roles and associated permissions
    /// </summary>
    /// <returns></returns>
    public List<Role> GetRoles()
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        List<Role> roles = new List<Role>();
        try
        {

            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Select id_role, nom from Role";
            NpgsqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Role role = new Role();
                role.id = reader[0].ToString();
                role.name = reader[1].ToString();
                role.permissions = GetPermissions(role.id);
                roles.Add(role);
            }
        }
        finally
        {
            conn.Close();

        }
        return roles;

    }
    /// <summary>
    /// Add a permission to a role
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="permissionId"></param>
    /// <returns></returns>
    public int AddRolePermission(String roleId, String permissionId)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        NpgsqlCommand command = new NpgsqlCommand();
        int nbAffectedColumns = 0;
        try
        {
        conn.Open();
        command.Connection = conn;
        command.CommandText = "Insert into Role_permission (id_role, id_permission) values (@p1, @p2)";
        command.Parameters.AddWithValue("p1",Convert.ToInt32(roleId));
        command.Parameters.AddWithValue("p2", Convert.ToInt32(permissionId));
        nbAffectedColumns = command.ExecuteNonQuery();
        } finally
        {
            conn.Close();
        }
        
        return nbAffectedColumns;
    }
    /// <summary>
    /// Delete all the permissions associated with a role
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public int DeleteRolePermission(string roleId)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        int nbAffectedColumns = 0;
        try
        {
        NpgsqlCommand command = new NpgsqlCommand();
        conn.Open();
        command.Connection = conn;
        command.CommandText = "Delete from Role_permission where id_role = @p1";
        command.Parameters.AddWithValue("p1", Convert.ToInt32(roleId));
        nbAffectedColumns = command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
        
        return nbAffectedColumns;
    }
    /// <summary>
    /// Delete the permission associated to the role
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="permissionId"></param>
    /// <returns></returns>
    public int DeleteRolePermission(string roleId, string permissionId)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        int nbAffectedColumns = 0;
        try
        {
            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "Delete from Role_permission where id_role = @p1 AND id_permission = @p2";
            command.Parameters.AddWithValue("p1", Convert.ToInt32(roleId));
            command.Parameters.AddWithValue("p2", Convert.ToInt32(permissionId));
            nbAffectedColumns = command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }

        return nbAffectedColumns;
    }
    /// <summary>
    /// Get the permissions associated with a role.
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public List<Permission> GetPermissions(string roleId)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        List<Permission> permissions = new List<Permission>();
       
        try
        {
            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
                command.CommandText = "select * from role_permission rolePerm" +
                    " join permission perm on rolePerm.id_permission = perm.id_permission" +
                    " where rolePerm.id_role = @p1";
                command.Parameters.AddWithValue("p1", Convert.ToInt32(roleId));
            NpgsqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return permissions;
            }
            while (reader.Read())
            {
                Permission permission = new Permission();
                // If no locale is set, use the default locale, otherwise try with the locale provided
                if (String.IsNullOrEmpty(locale) || reader.GetOrdinal("nom_" + locale) == -1)
                {
                    permission.localizedName = reader[reader.GetOrdinal("nom_" + defaultLocale)].ToString();
                }
                else
                {
                    permission.localizedName = reader[reader.GetOrdinal("nom_" + locale)].ToString();
                }
                
                permission.id = reader[reader.GetOrdinal("id_permission")].ToString();
                permission.code = reader[reader.GetOrdinal("code")].ToString();
                permissions.Add(permission);
            }
        }
        finally
        {
            conn.Close();

        }
        return permissions;
    }
    /// <summary>
    /// Get all the permissions
    /// </summary>
    /// <returns></returns>
    public List<Permission> GetPermissions()
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        List<Permission> permissions = new List<Permission>();

        try
        {
            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from permission";
            NpgsqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }
            while (reader.Read())
            {
                Permission permission = new Permission();
                if (String.IsNullOrEmpty(locale) || reader.GetOrdinal("nom_" + locale) == -1)
                {
                    permission.localizedName = reader[reader.GetOrdinal("nom_" + defaultLocale)].ToString();
                }
                else
                {
                    permission.localizedName = reader[reader.GetOrdinal("nom_" + locale)].ToString();
                }

                permission.id = reader[reader.GetOrdinal("id_permission")].ToString();
                permission.code = reader[reader.GetOrdinal("code")].ToString();
                permissions.Add(permission);
            }


        }
        finally
        {
            conn.Close();

        }

        return permissions;

    }
}




public class User
{
    public string id { get; set; }
    public string name { get; set; }
  
        public void setPasswordHash(string password, bool isAlreadyHashed)
    {
        if (!isAlreadyHashed)
        {
            password = new PasswordHasher().HashPassword(password);
        }
        passwordHash = password;
    }
    public string passwordHash { get; private set; }
    public Role role { get; set; }

}

    public class Permission
{
    public string id { get; set; }
    public string code { get; set; }
    public string localizedName { get; set; }
}

public class Role
{
    public string id { get; set; }
    public string name { get; set; }

    public List<Permission> permissions { get; set; }


}