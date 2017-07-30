using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;

public partial class Account_Machine : System.Web.UI.Page
{
    private string connstring = String.Format("Server={0};Port={1};" +
    "User Id={2};Password={3};Database={4}; SSL Mode={5};Trust Server Certificate={6};",
    "ec2-107-21-99-176.compute-1.amazonaws.com", "5432", "hufmyrumplrijg",
    "4ca6ce8f25630fbd310b32bcff802ec4e01e881797340a87c1cd74c771367874", "d99keabq5d8r02", "Require", "True");
    private DataSet ds = new DataSet();
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        select_All();
    }
    protected void select_All()
    {
        try
        {
            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            // quite complex sql statement
            string sql = "SELECT * FROM machine";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                MachineGridView.DataSource = ds;
                MachineGridView.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                MachineGridView.DataSource = ds;
                MachineGridView.DataBind();
                int columncount = MachineGridView.Rows[0].Cells.Count;
                MachineGridView.Rows[0].Cells.Clear();
                MachineGridView.Rows[0].Cells.Add(new TableCell());
                MachineGridView.Rows[0].Cells[0].ColumnSpan = columncount;
                MachineGridView.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg);
            throw;
        }
    }
    protected void delete(Object sender,
                               EventArgs e)
    {
        string deleteId = Request.Form["deleteId"];
        try
        {
            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            // quite complex sql statement
            string sql = "Delete FROM machine Where id_machine = " + deleteId + "";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg);
            throw;
        }
    }

    protected void insert(Object sender,
                           EventArgs e)
    {
        string addId = Request.Form["addorupdateID"];
        string addName = Request.Form["addorupdateMarque"];
        string addModele = Request.Form["addorupdateModele"];
        string addMarque = Request.Form["addorupdateMarque"];
        string addHauteur = Request.Form["addorupdateHauteur"];
        string addLargeur = Request.Form["addorupdateLargeur"];
        string addPoid = Request.Form["addorupdatePoid"];
        string addCapacite = Request.Form["addorupdateCapacite"];
        string addNbHeure = Request.Form["addorupdateNbHeure"];
        string addCompatibilite = Request.Form["addorupdateCompatibilite"];
        try
        {

            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            // quite complex sql statement
            string sql = "Insert into machine (id_machine,marque,modele,hauteur,largeur,poids,capacite,nb_heure_entre_entretient,type_compatibilite) Values(" + addId + ",'" + addMarque + "','"+addModele+"',"+addHauteur+ "," + addLargeur + "," + addPoid + "," + addCapacite + "," + addNbHeure + ",'"+addCompatibilite+"')";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg);
            throw;
        }
    }

    protected void update(Object sender,
                       EventArgs e)
    {
        string updateId = Request.Form["addorupdateID"];
        string updateName = Request.Form["addorupdateMarque"];
        string updateModele = Request.Form["addorupdateModele"];
        string updateMarque = Request.Form["addorupdateMarque"];
        string updateHauteur = Request.Form["addorupdateHauteur"];
        string updateLargeur = Request.Form["addorupdateLargeur"];
        string updatePoid = Request.Form["addorupdatePoid"];
        string updateCapacite = Request.Form["addorupdateCapacite"];
        string updateNbHeure = Request.Form["addorupdateNbHeure"];
        string updateCompatibilite = Request.Form["addorupdateCompatibilite"];
        try
        {

            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            // quite complex sql statement
            string sql = "UPDATE machine (marque,modele,hauteur,largeur,poids,capacite,nb_heure_entre_entretient,type_compatibilite) Values('" + updateMarque + "','" + updateModele + "'," + updateHauteur + "," + updateLargeur + "," + updatePoid + "," + updateCapacite + "," + updateNbHeure + ",'" + updateCompatibilite + "') WHERE id_machine = "+ updateId + "";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg);
            throw;
        }
    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        select_All();
    }
    protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        select_All();
    }
    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        select_All();
    }
    protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        select_All();
    }
    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        select_All();
    }
}