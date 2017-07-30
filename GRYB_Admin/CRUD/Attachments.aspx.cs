using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;

public partial class Account_Attachments : System.Web.UI.Page
{
    private string connstring = String.Format("Server={0};Port={1};" +
    "User Id={2};Password={3};Database={4}; SSL Mode={5};Trust Server Certificate={6};",
    "ec2-107-21-99-176.compute-1.amazonaws.com", "5432", "hufmyrumplrijg",
    "4ca6ce8f25630fbd310b32bcff802ec4e01e881797340a87c1cd74c771367874", "d99keabq5d8r02", "Require", "True");
    private DataSet ds = new DataSet();
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            select_All();
        }
    }
    protected void select_All()
    {
        try
        {
            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            // quite complex sql statement
            string sql = "SELECT * FROM attachement";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                AttachmentGridView.DataSource = ds;
                AttachmentGridView.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                AttachmentGridView.DataSource = ds;
                AttachmentGridView.DataBind();
                int columncount = AttachmentGridView.Rows[0].Cells.Count;
                AttachmentGridView.Rows[0].Cells.Clear();
                AttachmentGridView.Rows[0].Cells.Add(new TableCell());
                AttachmentGridView.Rows[0].Cells[0].ColumnSpan = columncount;
                AttachmentGridView.Rows[0].Cells[0].Text = "No Records Found";
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
            string sql = "Delete FROM attachement Where id_attachement = " + deleteId + "";
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
        string addNumAttachement = Request.Form["addorupdateNumAttachement"];
        string addNumSerie = Request.Form["addorupdateNumSerie"];
        string addCompatibilite = Request.Form["addorupdateCompatibilite"];
        string addMarque = Request.Form["addorupdateMarque"];
        string addModele = Request.Form["addorupdateModele"];
        string addHauteur = Request.Form["addorupdateHauteur"];
        string addLargeur = Request.Form["addorupdateLargeur"];
        string addNbHeure = Request.Form["addorupdateNbHeure"];
        try
        {

            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            // quite complex sql statement
            string sql = "Insert into attachement (id_attachement,numero_attachement,numero_serie,type_compatibilite,marque,modele,hauteur,largeur,nb_heure_entre_entretient) Values(" + addId + ",'" + addNumAttachement + "','" + addNumSerie + "'," + addCompatibilite + "," + addMarque + "," + addModele + "," + addHauteur + "," + addLargeur + ",'" + addNbHeure + "')";
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
        string updateNumAttachement = Request.Form["addorupdateNumAttachement"];
        string updateNumSerie = Request.Form["addorupdateNumSerie"];
        string updateCompatibilite = Request.Form["addorupdateCompatibilite"];
        string updateMarque = Request.Form["addorupdateMarque"];
        string updateModele = Request.Form["addorupdateModele"];
        string updateHauteur = Request.Form["addorupdateHauteur"];
        string updateLargeur = Request.Form["addorupdateLargeur"];
        string updateNbHeure = Request.Form["addorupdateNbHeure"];
        try
        {

            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            // quite complex sql statement
            string sql = "UPDATE attachement SET (numero_attachement,numero_serie,type_compatibilite,marque,modele,hauteur,largeur,nb_heure_entre_entretient) Values('" + updateNumAttachement + "','" + updateNumSerie + "'," + updateCompatibilite + "," + updateMarque + "," + updateModele + "," + updateHauteur + "," + updateLargeur + ",'" + updateNbHeure + "') WHERE id_attachement = "+updateId+"";
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