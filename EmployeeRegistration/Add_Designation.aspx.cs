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
    public partial class Add_Designation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayDepartment();
                DisplayDesignation();
            }
        }

        public void Clear()
        {
            ddldepartment.SelectedValue = "0";
            txtdesignation.Text = "";
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
            ddldepartment.DataValueField = "DepartmentID";
            ddldepartment.DataTextField = "DepartmentName";
            ddldepartment.DataSource = dt;
            ddldepartment.DataBind();
            ddldepartment.Items.Insert(0, new ListItem("-----Select-----", "0"));
        }
        public void DisplayDesignation()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "DesignationShow");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdvdd.DataSource = dt;
            grdvdd.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DesignationInsert");
                cmd.Parameters.AddWithValue("@DepartmentID", ddldepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@DesignationName", txtdesignation.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayDesignation();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DesignationUpdate");
                cmd.Parameters.AddWithValue("@DepartmentID", ddldepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@DesignationName", txtdesignation.Text);
                cmd.Parameters.AddWithValue("@DesignationID", ViewState["DesignationID"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayDesignation();
            }
        }

        protected void grdvdd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StatusDesignation");
                cmd.Parameters.AddWithValue("@DesignationID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayDesignation();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DesignationEdit");
                cmd.Parameters.AddWithValue("@DesignationID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                ddldepartment.SelectedValue = dt.Rows[0]["DepartmentID"].ToString();
                txtdesignation.Text = dt.Rows[0]["DesignationName"].ToString();
                ViewState["DesignationID"] = e.CommandArgument;
                btnsave.Text = "Update";
            }
        }
    }
}