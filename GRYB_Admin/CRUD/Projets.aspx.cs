using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
using System.Drawing;

public partial class Account_Projets : System.Web.UI.Page
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
            string sql = "SELECT * FROM projet";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ProjectGridView.DataSource = ds;
                ProjectGridView.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                ProjectGridView.DataSource = ds;
                ProjectGridView.DataBind();
                int columncount = ProjectGridView.Rows[0].Cells.Count;
                ProjectGridView.Rows[0].Cells.Clear();
                ProjectGridView.Rows[0].Cells.Add(new TableCell());
                ProjectGridView.Rows[0].Cells[0].ColumnSpan = columncount;
                ProjectGridView.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = "Une erreur s'est produite : " + msg.ToString();
        }
    }
    
    protected void insert(Object sender,
                           EventArgs e)
    {
        //Get data from the form
        string addName = Request.Form["addName"];
        try
        {
            //Connect to the DB
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            //The Insert SQL command to execute
            string sql = "Insert into projet (nom) Values('"+addName+"')";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = "Une erreur s'est produite : " + msg.ToString();
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
            string sql = "Delete FROM projet Where id_projet = " + Convert.ToInt32(ProjectGridView.DataKeys[e.RowIndex].Value.ToString()) + "";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
            select_All();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = "Une erreur s'est produite : " + msg.ToString();
        }
        
    }
    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            //Get the value from the GridView
            int projectID = Convert.ToInt32(ProjectGridView.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)ProjectGridView.Rows[e.RowIndex];
            TextBox text_Name = (TextBox)row.FindControl("name_Text");
            ProjectGridView.EditIndex = -1;
            //Connect to the DB
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            //The Update SQL command to execute
            string sql = "UPDATE projet SET nom='" + text_Name.Text + "' WHERE id_projet = " + projectID + "";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            select_All();
        }
        catch (Exception msg)
        {
            //DB error are trown in a Label
            ErrorManagement.Text = "Une erreur s'est produite : " + msg.ToString();
        }
    }
    //The commands that are in charge of the transition in the grid view
    protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ProjectGridView.EditIndex = e.NewEditIndex;
        select_All();
    }
    protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ProjectGridView.EditIndex = -1;
        select_All();
    }
    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ProjectGridView.PageIndex = e.NewPageIndex;
        select_All();
    }

}