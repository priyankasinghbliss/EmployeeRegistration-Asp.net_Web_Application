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
    public partial class Add_Department : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayDepartment();
            }
        }

        public void Clear()
        {
            txtdepartment.Text = "";
            btnsave.Text = "Save";
        }
        public void DisplayDepartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "DepartmentShow");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdvd.DataSource = dt;
            grdvd.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DepartmentInsert");
                cmd.Parameters.AddWithValue("@DepartmentName", txtdepartment.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayDepartment();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DepartmentUpdate");
                cmd.Parameters.AddWithValue("@DepartmentName", txtdepartment.Text);
                cmd.Parameters.AddWithValue("@DepartmentID", ViewState["DepartmentID"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayDepartment();
            }
        }

        protected void grdvd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StatusDepartment");
                cmd.Parameters.AddWithValue("@DepartmentID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayDepartment();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DepartmentEdit");
                cmd.Parameters.AddWithValue("@DepartmentID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtdepartment.Text = dt.Rows[0]["DepartmentName"].ToString();
                ViewState["DepartmentID"] = e.CommandArgument;
                btnsave.Text = "Update";
            }
        }
    }
}