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
    public partial class Employee_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
                DisplayGender();
                DisplayCountry();
                DisplayDepartment();
                ddlstate.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("-----Select-----", "0"));
                ddlcity.Enabled = false;
                ddlcity.Items.Insert(0, new ListItem("-----Select-----", "0"));
                ddldesignation.Enabled = false;
                ddldesignation.Items.Insert(0, new ListItem("-----Select-----", "0"));
            }
        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Join");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdv.DataSource = dt;
            grdv.DataBind();
        }
        public void Clear()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            rblgender.ClearSelection();
            txtage.Text = "";
            txtmobile.Text = "";
            txtemail.Text = "";
            txtempcode.Text = "";
            txtsalary.Text = "";
            txtaddress.Text = "";
            ddlcountry.SelectedValue = "0";
            ddlstate.Enabled = false;
            ddlstate.SelectedValue = "0";
            ddlcity.Enabled = false;
            ddlcity.SelectedValue = "0";
            ddldepartment.SelectedValue = "0";
            ddldesignation.Enabled = false;
            ddldesignation.SelectedValue = "0";
            txtpassword.Text = "";
            txtcpassword.Text = "";
            btnsubmit.Text = "Submit";
        }
        public void DisplayGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Gender");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblgender.DataValueField = "GenderID";
            rblgender.DataTextField = "GenderName";
            rblgender.DataSource = dt;
            rblgender.DataBind();
        }
        public void DisplayCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Country");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "CountryID";
            ddlcountry.DataTextField = "CountryName";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("-----Select-----", "0"));
        }
        public void DisplayState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "State");
            cmd.Parameters.AddWithValue("@CountryID", ddlcountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.Enabled = true;
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
            cmd.Parameters.AddWithValue("@action", "City");
            cmd.Parameters.AddWithValue("@StateID", ddlstate.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.Enabled = true;
            ddlcity.DataValueField = "CityID";
            ddlcity.DataTextField = "CityName";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("-----Select-----", "0"));
        }
        public void DisplayDepartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Department");
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
            cmd.Parameters.AddWithValue("@action", "Designation");
            cmd.Parameters.AddWithValue("@DepartmentID", ddldepartment.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddldesignation.Enabled = true;
            ddldesignation.DataValueField = "DesignationID";
            ddldesignation.DataTextField = "DesignationName";
            ddldesignation.DataSource = dt;
            ddldesignation.DataBind();
            ddldesignation.Items.Insert(0, new ListItem("-----Select-----", "0"));
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Insert");
                cmd.Parameters.AddWithValue("@Employee_Code", txtempcode.Text);
                cmd.Parameters.AddWithValue("@First_Name", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlastname.Text);
                cmd.Parameters.AddWithValue("@Gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@Age" , txtage.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@City", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@State", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@Country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@Department", ddldepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@Designation", ddldesignation.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", txtsalary.Text);
                cmd.Parameters.AddWithValue("@Mobile_No", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Email_ID", txtemail.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                //cmd.Parameters.AddWithValue("@Created_On", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                //cmd.Parameters.AddWithValue("@Modified_On", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    lblmsg.Text = "Your record is saved successfully!!";
                }
                else
                {
                    lblmsg.Text = "Your record is not saved!!";
                }
                con.Close();
                Clear();
                Display();
            }
            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Update");
                cmd.Parameters.AddWithValue("@ID", ViewState["ID"]);
                cmd.Parameters.AddWithValue("@Employee_Code", txtempcode.Text);
                cmd.Parameters.AddWithValue("@First_Name", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlastname.Text);
                cmd.Parameters.AddWithValue("@Gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@City", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@State", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@Country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@Department", ddldepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@Designation", ddldesignation.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", txtsalary.Text);
                cmd.Parameters.AddWithValue("@Mobile_No", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Email_ID", txtemail.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                //cmd.Parameters.AddWithValue("@Modified_On", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    lblmsg.Text = "Your record Updated successfully!!";
                }
                con.Close();
                Clear();
                Display();
            }
        }

        protected void grdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Delete");
                cmd.Parameters.AddWithValue("@ID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Edit");
                cmd.Parameters.AddWithValue("@ID", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtfirstname.Text = dt.Rows[0]["First_Name"].ToString();
                txtlastname.Text = dt.Rows[0]["Last_Name"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                //txtdob.Text = Convert.ToDateTime(dt.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                txtage.Text = dt.Rows[0]["Age"].ToString();
                txtempcode.Text = dt.Rows[0]["Employee_Code"].ToString();
                txtsalary.Text = dt.Rows[0]["Salary"].ToString();
                txtaddress.Text = dt.Rows[0]["Address"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["Country"].ToString();
                DisplayState();
                ddlstate.SelectedValue = dt.Rows[0]["State"].ToString();
                DisplayCity();
                ddlcity.SelectedValue = dt.Rows[0]["City"].ToString();
                ddldepartment.SelectedValue = dt.Rows[0]["Department"].ToString();
                DisplayDesignation();
                ddldesignation.SelectedValue = dt.Rows[0]["Designation"].ToString();
                txtmobile.Text = dt.Rows[0]["Mobile_No"].ToString();
                txtemail.Text = dt.Rows[0]["Email_ID"].ToString();
                txtpassword.Text = dt.Rows[0]["Password"].ToString();
                txtcpassword.Text = dt.Rows[0]["Password"].ToString();
                ViewState["ID"] = e.CommandArgument;
                btnsubmit.Text = "Update";
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcountry.SelectedValue == "0")
            {
                ddlstate.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlcity.Enabled = false;
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                DisplayState();
            }
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstate.SelectedValue == "0")
            {
                ddlcity.Enabled = false;
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                DisplayCity();
            }
        }

        protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddldepartment.SelectedValue == "0")
            {
                ddldesignation.Enabled = false;
                ddldesignation.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                DisplayDesignation();
            }

        }
    }
}