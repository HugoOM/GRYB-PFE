using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IdentityManager
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

    public IdentityResult CreateUser(User user)
    {
        if (GetUser(user.name) != null)
        {
            return new IdentityResult("a user with this name already exist");
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
            return new IdentityResult("Operation failed, the user was not added");
        }
        return IdentityResult.Success; // rien = succès?
    }

    // Avoid situations where the user is locked out of his own system because he forgot the superAdmin password
   /* internal void CreateDefaultUserIfAbsent()
    {
        Role role = GetRole()
        User user = GetUser("super admin");
        if (GetUser("superAdmin") == null)
        {
            user = new User();
            user.name = "super admin";
            user.setPasswordHash("admin", false);
            user.role = 
            CreateUser()
        }
    }*/

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

    public User Login(String name, String plainPassword)
    {
        User user = GetUser(name);
        if (user == null)
        {
            return null;
        }

        PasswordHasher hasher = new PasswordHasher();
        PasswordVerificationResult r = new PasswordVerificationResult();
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
        //TODO check if you want to return user or identityResult
    }

    public IdentityResult ChangePassword(string userName, string oldPasswordPlain, string newPasswordPlain)
    {
       // oldPasswordPlain = new PasswordHasher().HashPassword(oldPasswordPlain);
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



    // Update the user only, and not the associated role and permissions
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
        //int nbAffectedColumns = command.ExecuteNonQuery();

        return role;

    }

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
        //int nbAffectedColumns = command.ExecuteNonQuery();

        return role;

    }

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

    public List<Permission> GetPermissions(string roleId)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        List<Permission> permissions = new List<Permission>();
       
        try
        {

            /*  NpgsqlCommand command = new NpgsqlCommand();
              conn.Open();
              command.Connection = conn;
              command.CommandText = "select perm.id_permission, perm.code, perm.nom_" + locale + " from role_permission rolePerm" +
                     " join permission perm on rolePerm.id_permission = perm.id_permission" +
                     " where rolePerm.id_role = @p1";
              command.Parameters.AddWithValue("p1", Convert.ToInt32(roleId));
              NpgsqlDataReader reader;*/
            //  try
            // {
            //reader = command.ExecuteReader();
            //  } catch(Exception e)
            //  {
            // Fall back on the default name
            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
                command.CommandText = "select * from role_permission rolePerm" +
                    " join permission perm on rolePerm.id_permission = perm.id_permission" +
                    " where rolePerm.id_role = @p1";
                command.Parameters.AddWithValue("p1", Convert.ToInt32(roleId));
            NpgsqlDataReader reader = command.ExecuteReader();

         //   }
            if (!reader.HasRows)
            {
                return permissions;
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
                // role.permissions = GetPermissions(role.id);
                permissions.Add(permission);
            }
            
            
        }
        finally
        {
            conn.Close();

        }
        //int nbAffectedColumns = command.ExecuteNonQuery();

        return permissions;

    }

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

            //   }
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
        //int nbAffectedColumns = command.ExecuteNonQuery();

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
            password = new PasswordHasher().HashPassword(password);//FIXME will it work?
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