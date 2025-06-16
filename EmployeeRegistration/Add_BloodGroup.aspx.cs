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
    public partial class Add_BloodGroup : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayBloodGroup();
            }
        }

        public void Clear()
        {
            txtbloodgroup.Text = "";
            btnsave.Text = "Save";
        }
        public void DisplayBloodGroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "BGShow");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdvbg.DataSource = dt;
            grdvbg.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "BGInsert");
                cmd.Parameters.AddWithValue("@BGName", txtbloodgroup.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayBloodGroup();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "BGUpdate");
                cmd.Parameters.AddWithValue("@BGName", txtbloodgroup.Text);
                cmd.Parameters.AddWithValue("@BGID", ViewState["BGID"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayBloodGroup();
            }
        }

        protected void grdvbg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StatusBG");
                cmd.Parameters.AddWithValue("@BGID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayBloodGroup();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "BGEdit");
                cmd.Parameters.AddWithValue("@BGID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtbloodgroup.Text = dt.Rows[0]["BGName"].ToString();
                ViewState["BGID"] = e.CommandArgument;
                btnsave.Text = "Update";
            }
        }
    }
}