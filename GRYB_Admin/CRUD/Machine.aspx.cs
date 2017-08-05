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
    //Connection string to the database
    private string connstring = String.Format("Server={0};Port={1};" +
    "User Id={2};Password={3};Database={4}; SSL Mode={5};Trust Server Certificate={6};",
    "ec2-107-21-99-176.compute-1.amazonaws.com", "5432", "hufmyrumplrijg",
    "4ca6ce8f25630fbd310b32bcff802ec4e01e881797340a87c1cd74c771367874", "d99keabq5d8r02", "Require", "True");
    private DataSet ds = new DataSet();
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Fill the GridView/refresh the GridView
        if (!IsPostBack)
        {
            select_All();
        }
    }
    protected void select_All()
    {
        try
        {
            //Opening the connection to the DB
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            //The Select SQL Command to execute
            string sql = "SELECT * FROM machine";
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
            //DB error are trown in a Label
            ErrorManagement.Text = "une erreur s'est produite : " + msg.ToString();
        }
    }

    protected void insert(Object sender,
                           EventArgs e)
    {
        //Get data from the form
        string addModele = addModeleText.Text;
        string addMarque = addMarqueText.Text;
        string addHauteur = addHauteurText.Text;
        string addLargeur = addLargeurText.Text;
        string addPoid = addPoidText.Text;
        string addCapacite = addCapaciteText.Text;
        string addNbHeure = addNbHeureText.Text;
        string addCompatibilite = addCompatibiliteText.Text;
        try
        {

            //Connect to the DB
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            //The Insert SQL command to execute
            string sql = "Insert into machine (marque,modele,hauteur,largeur,poids,capacite,nb_heure_entre_entretient,type_compatibilite) Values('" + addMarque + "','"+addModele+"',"+addHauteur+ "," + addLargeur + "," + addPoid + "," + addCapacite + "," + addNbHeure + ",'"+addCompatibilite+"')";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            select_All();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = "une erreur s'est produite : " + msg.ToString();
        }
    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //Connect to the DB
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            //The Delete SQL command to execute
            string sql = "Delete FROM machine Where id_machine = " + Convert.ToInt32(MachineGridView.DataKeys[e.RowIndex].Value.ToString()) + "";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            select_All();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = "une erreur s'est produite : " + msg.ToString();
        }
    }
    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            //Get the value from the GridView
            int machineID = Convert.ToInt32(MachineGridView.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)MachineGridView.Rows[e.RowIndex];
            TextBox text_Marque = (TextBox)row.FindControl("marque_Text");
            TextBox text_Modele = (TextBox)row.FindControl("modele_Text");
            TextBox text_Hauteur = (TextBox)row.FindControl("hauteur_Text");
            TextBox text_Largeur = (TextBox)row.FindControl("largeur_Text");
            TextBox text_Poids = (TextBox)row.FindControl("poids_Text");
            TextBox text_Capacite = (TextBox)row.FindControl("capacite_Text");
            TextBox text_Nb_heure_entre_entretient = (TextBox)row.FindControl("nb_heure_entre_entretient_Text");
            TextBox text_Type_compatibilite = (TextBox)row.FindControl("type_compatibilite_Text");
            MachineGridView.EditIndex = -1;
            //Connect to the DB
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            //The Update SQL command to execute
            string sql = "UPDATE machine SET marque='" + text_Marque.Text + "', modele='" + text_Modele.Text + "',hauteur='" + text_Hauteur.Text + "'," +
                "largeur='" + text_Largeur.Text + "',poids='" + text_Poids.Text + "',capacite='" + text_Capacite.Text + "',nb_heure_entre_entretient='" + text_Nb_heure_entre_entretient.Text + "'," +
                "type_compatibilite='" + text_Type_compatibilite.Text + "' WHERE id_machine = " + machineID + "";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            select_All();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = "une erreur s'est produite : " + msg.ToString();
        }
    }
    //The commands that are in charge of the transition in the grid view
    protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        MachineGridView.EditIndex = e.NewEditIndex;
        select_All();
    }
    protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        MachineGridView.EditIndex = -1;
        select_All();
    }
    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        MachineGridView.PageIndex = e.NewPageIndex;
        select_All();
    }
}