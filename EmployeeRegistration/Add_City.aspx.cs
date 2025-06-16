using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeRegistration
{
    public partial class Add_City : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayState();
                DisplayCity();
            }
        }

        public void Clear()
        {
            ddlstate.SelectedValue = "0";
            txtcity.Text = "";
            btnsave.Text = "Save";
        }

        public void DisplayState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "StateShow");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "StateID";
            ddlstate.DataTextField = "StateName";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("-----Select-----", "0"));
        }
        public void DisplayCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "CityJoin");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdvcc.DataSource = dt;
            grdvcc.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CityInsert");
                cmd.Parameters.AddWithValue("@StateID", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@CityName", txtcity.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayCity();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CityUpdate");
                cmd.Parameters.AddWithValue("@StateID", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@CityName", txtcity.Text);
                cmd.Parameters.AddWithValue("@CityID", ViewState["CityID"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayCity();
            }
        }

        protected void grdvcc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StatusCity");
                cmd.Parameters.AddWithValue("@CityID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayCity();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CityEdit");
                cmd.Parameters.AddWithValue("@CityID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                ddlstate.SelectedValue = dt.Rows[0]["StateID"].ToString();
                txtcity.Text = dt.Rows[0]["CityName"].ToString();
                ViewState["CityID"] = e.CommandArgument;
                btnsave.Text = "Update";
            }
        }
    }
}