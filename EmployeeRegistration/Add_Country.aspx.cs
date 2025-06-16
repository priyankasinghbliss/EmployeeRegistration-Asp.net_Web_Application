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
    public partial class Add_Country : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayCountry();
            }
        }
        public void Clear()
        {
            txtcountry.Text = "";
            btnsave.Text = "Save";
        }
        public void DisplayCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "CountryShow");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdvc.DataSource = dt;
            grdvc.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CountryInsert");
                cmd.Parameters.AddWithValue("@CountryName", txtcountry.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayCountry();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CountryUpdate");
                cmd.Parameters.AddWithValue("@CountryName", txtcountry.Text);
                cmd.Parameters.AddWithValue("@CountryID", ViewState["CountryID"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayCountry();
            }
        }
        protected void grdvc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StatusCountry");
                cmd.Parameters.AddWithValue("@CountryID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayCountry();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CountryEdit");
                cmd.Parameters.AddWithValue("@CountryID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                ViewState["CountryID"] = e.CommandArgument;
                btnsave.Text = "Update";
            }
        }
    }
}