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
    public partial class Add_MaritalStatus : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayMaritalStatus();
            }
        }

        public void Clear()
        {
            txtmaritalstatus.Text = "";
            btnsave.Text = "Save";
        }
        public void DisplayMaritalStatus()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "MSShow");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdvms.DataSource = dt;
            grdvms.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "MSInsert");
                cmd.Parameters.AddWithValue("@MSName", txtmaritalstatus.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayMaritalStatus();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "MSUpdate");
                cmd.Parameters.AddWithValue("@MSName", txtmaritalstatus.Text);
                cmd.Parameters.AddWithValue("@MSID", ViewState["MSID"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayMaritalStatus();
            }
        }
        protected void grdvms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Status")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StatusMS");
                cmd.Parameters.AddWithValue("@MSID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayMaritalStatus();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "MSEdit");
                cmd.Parameters.AddWithValue("@MSID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtmaritalstatus.Text = dt.Rows[0]["MSName"].ToString();
                ViewState["MSID"] = e.CommandArgument;
                btnsave.Text = "Update";
            }
        }
    }
}