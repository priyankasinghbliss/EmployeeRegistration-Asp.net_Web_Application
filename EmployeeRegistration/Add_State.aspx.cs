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
    public partial class Add_State : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayCountry();
                DisplayState();
            }
        }

        public void Clear()
        {
            ddlcountry.SelectedValue = "0";
            txtstate.Text = "";
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
            ddlcountry.DataValueField = "CountryID";
            ddlcountry.DataTextField = "CountryName";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem ("-----Select-----","0"));
        }
        public void DisplayState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "StateJoin");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdvs.DataSource = dt;
            grdvs.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StateInsert");
                cmd.Parameters.AddWithValue("@CountryID", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StateName", txtstate.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayState();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StateUpdate");
                cmd.Parameters.AddWithValue("@CountryID", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StateName", txtstate.Text);
                cmd.Parameters.AddWithValue("@StateID", ViewState["StateID"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                DisplayState();
            }
        }

        protected void grdvs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StatusState");
                cmd.Parameters.AddWithValue("@StateID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayState();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "StateEdit");
                cmd.Parameters.AddWithValue("@StateID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                ddlcountry.SelectedValue = dt.Rows[0]["CountryID"].ToString();
                txtstate.Text = dt.Rows[0]["StateName"].ToString();
                ViewState["StateID"] = e.CommandArgument;
                btnsave.Text = "Update";
            }
        }
    }
}