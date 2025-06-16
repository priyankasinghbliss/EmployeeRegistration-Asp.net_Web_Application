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
    public partial class Add_Gender : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayGender();
            }
        }

        public void Clear()
        {
            txtgender.Text = "";
            btnsave.Text = "Save";
        }
        public void DisplayGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GenderShow");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdvg.DataSource = dt;
            grdvg.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GenderInsert");
                cmd.Parameters.AddWithValue("@GenderName", txtgender.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayGender();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GenderUpdate");
                cmd.Parameters.AddWithValue("@GenderName", txtgender.Text);
                cmd.Parameters.AddWithValue("@GenderID", ViewState["GenderID"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayGender();
            }
        }
        protected void grdvg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StatusGender");
                cmd.Parameters.AddWithValue("@GenderID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGender();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GenderEdit");
                cmd.Parameters.AddWithValue("@GenderID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtgender.Text = dt.Rows[0]["GenderName"].ToString();
                ViewState["GenderID"] = e.CommandArgument;
                btnsave.Text = "Update";
            }
        }
    }
}