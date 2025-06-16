using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace EmployeeRegistration
{
    public partial class Employee_Add : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["EmpId"] != null && Request.QueryString["EmpId"] != "")
                {
                    Edit();
                }
                DisplayGender();
                DisplayMaritalStatus();
                DisplayBloodGroup();
            }
        }
        public void Clear()
        {
            txtname.Text = "";
            rblgender.ClearSelection();
            txtdob.Text = "";
            ddlmaritalstatus.SelectedValue = "0";
            ddlbloodgroup.SelectedValue = "0";
            txtjoiningdate.Text = "";
            btnsave.Text = "Save";
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
        public void DisplayMaritalStatus()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "MaritalStatus");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlmaritalstatus.DataValueField = "MSID";
            ddlmaritalstatus.DataTextField = "MSName";
            ddlmaritalstatus.DataSource = dt;
            ddlmaritalstatus.DataBind();
            ddlmaritalstatus.Items.Insert(0, new ListItem("-----Select-----", "0"));
        }
        public void DisplayBloodGroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "BloodGroup");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlbloodgroup.DataValueField = "BGID";
            ddlbloodgroup.DataTextField = "BGName";
            ddlbloodgroup.DataSource = dt;
            ddlbloodgroup.DataBind();
            ddlbloodgroup.Items.Insert(0, new ListItem("-----Select-----", "0"));
        }
        public void Edit()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "EditProfile");
            cmd.Parameters.AddWithValue("@EmpID", Request.QueryString["EmpId"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            txtname.Text = dt.Rows[0]["Name"].ToString();
            rblgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
            txtdob.Text = dt.Rows[0]["Dateofbirth"].ToString();
            ddlmaritalstatus.SelectedValue = dt.Rows[0]["Marital_Status"].ToString();
            ddlbloodgroup.SelectedValue = dt.Rows[0]["Blood_Group"].ToString();
            txtjoiningdate.Text = dt.Rows[0]["Joindate"].ToString();
            ViewState["Img"] = dt.Rows[0]["Image"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["Image"].ToString()))
            {
                Image1.ImageUrl = string.Concat("Emp_ProfilePics/", dt.Rows[0]["Image"].ToString());
                imglbl.Text = dt.Rows[0]["Image"].ToString();
            }
            else
            {
                Image1.ImageUrl = string.Concat("Emp_ProfilePics/", "No Image Available");
            }
            btnsave.Text = "Update";
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                string newImageName = string.Empty;
                string FN = Path.GetFileName(fuimage.PostedFile.FileName);
                string fileext = Path.GetExtension(FN);
                newImageName = string.Concat(txtname.Text, "_00_", fileext);
                fuimage.SaveAs(Server.MapPath("Emp_ProfilePics" + "\\" + newImageName));
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "InsertProfile");
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@DOB", txtdob.Text);
                cmd.Parameters.AddWithValue("@MaritalStatus", ddlmaritalstatus.SelectedValue);
                cmd.Parameters.AddWithValue("@BloodGroup", ddlbloodgroup.SelectedValue);
                cmd.Parameters.AddWithValue("@Joining_Date", txtjoiningdate.Text);
                if (FN != null)
                {
                    cmd.Parameters.AddWithValue("@Image", newImageName);
                }

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    lblmessage.Text = "Your record is saved successfully!!";
                }
                else
                {
                    lblmessage.Text = "Your record is not saved!!";
                }
                con.Close();
                Clear();
                Response.Redirect("Employee_Show.aspx");
            }
            if (btnsave.Text == "Update")
            {
                string FN = Path.GetFileName(fuimage.PostedFile.FileName);
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UpdateProfile");
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@DOB", txtdob.Text);
                cmd.Parameters.AddWithValue("@MaritalStatus", ddlmaritalstatus.SelectedValue);
                cmd.Parameters.AddWithValue("@BloodGroup", ddlbloodgroup.SelectedValue);
                cmd.Parameters.AddWithValue("@Joining_Date", txtjoiningdate.Text);
                if (FN != "")
                {
                    cmd.Parameters.AddWithValue("@Image", FN);
                    fuimage.SaveAs(Server.MapPath("Emp_ProfilePics" + "\\" + FN));
                    File.Delete(Server.MapPath("Emp_ProfilePics" + "\\" + ViewState["Img"]));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Image", ViewState["Img"]);
                }
                cmd.Parameters.AddWithValue("@EmpID", Request.QueryString["EmpId"]);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Clear();
                    Response.Redirect("Employee_Show.aspx");
                }
                else
                {
                    lblmessage.Text = "Your record is not Updated!!";
                }
                con.Close();
            }
        }
    }
}