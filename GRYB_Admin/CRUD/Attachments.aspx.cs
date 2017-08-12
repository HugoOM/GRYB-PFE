using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
using System.Configuration;

public partial class Account_Attachments : System.Web.UI.Page
{
    //Connection string to the database
    private string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
            string sql = "SELECT * FROM attachement";
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
                AttachmentGridView.Rows[0].Cells[0].Text = Resources.General.NoRecordFound;
            }
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = Resources.General.AnErrorHasOccured + ": " + msg.ToString();
        }
    }

    protected void insert(Object sender,
                           EventArgs e)
    {
        //Get data from the form
        string addNumAttachement = addNumAttachementText.Text;
        string addNumSerie = addNumSerieText.Text;
        string addCompatibilite = addCompatibiliteText.Text;
        string addMarque = addMarqueText.Text;
        string addModele = addModeleText.Text;
        string addHauteur = addHauteurText.Text;
        string addLargeur = addLargeurText.Text;
        string addNbHeure = addNbHeureText.Text;
        try
        {
            //Connect to the DB
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            //The Insert SQL command to execute
            string sql = "Insert into attachement (numero_attachement,numero_serie,type_compatibilite,marque,modele,hauteur,largeur,nb_heure_entre_entretient) Values('" + addNumAttachement + "','" + addNumSerie + "','" + addCompatibilite + "','" + addMarque + "','" + addModele + "','" + addHauteur + "','" + addLargeur + "','" + addNbHeure + "')";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            select_All();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = Resources.General.AnErrorHasOccured + ": " + msg.ToString();
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
            string sql = "Delete FROM attachement Where id_attachement = " + Convert.ToInt32(AttachmentGridView.DataKeys[e.RowIndex].Value.ToString()) + "";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            select_All();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = Resources.General.AnErrorHasOccured + ": " + msg.ToString();
        }
    }
    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            //Get the value from the GridView
            int attachementID = Convert.ToInt32(AttachmentGridView.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)AttachmentGridView.Rows[e.RowIndex];
            TextBox text_Numero_attachement = (TextBox)row.FindControl("numero_attachement_Text");
            TextBox text_Numero_serie = (TextBox)row.FindControl("numero_serie_Text");
            TextBox text_Type_compatibilite = (TextBox)row.FindControl("type_compatibilite_Text");
            TextBox text_Marque = (TextBox)row.FindControl("marque_Text");
            TextBox text_Modele = (TextBox)row.FindControl("modele_Text");
            TextBox text_hauteur = (TextBox)row.FindControl("hauteur_Text");
            TextBox text_largeur = (TextBox)row.FindControl("largeur_Text");
            TextBox text_nb_heure_entre_entretient = (TextBox)row.FindControl("nb_heure_entre_entretient_Text");
            AttachmentGridView.EditIndex = -1;
            //Connect to the DB
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            //The Update SQL command to execute
            string sql = "UPDATE attachement SET numero_attachement='" + text_Numero_attachement.Text + "', numero_serie='" + text_Numero_serie.Text + "',type_compatibilite='" + text_Type_compatibilite.Text + "'," +
                "marque='" + text_Marque.Text + "',modele='" + text_Modele.Text + "',hauteur='" + text_hauteur.Text + "',largeur='" + text_largeur.Text + "'," +
                "nb_heure_entre_entretient='" + text_nb_heure_entre_entretient.Text + "' WHERE id_attachement = " + attachementID + "";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            select_All();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = Resources.General.AnErrorHasOccured + ": " + msg.ToString();
        }
    }
    //The commands that are in charge of the transition in the grid view
    protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AttachmentGridView.EditIndex = e.NewEditIndex;
        select_All();
    }
    protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        AttachmentGridView.EditIndex = -1;
        select_All();
    }
    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        AttachmentGridView.PageIndex = e.NewPageIndex;
        select_All();
    }
}