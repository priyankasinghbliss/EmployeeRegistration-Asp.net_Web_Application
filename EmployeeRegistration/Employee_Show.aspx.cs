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
    public partial class Employee_Show : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }

        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JoinProfile");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdv1.DataSource = dt;
            grdv1.DataBind();
        }
        protected void grdv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                String[] arr = e.CommandArgument.ToString().Split(',');
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DeleteProfile");
                cmd.Parameters.AddWithValue("@EmpID", arr[0]);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                File.Delete(Server.MapPath("Emp_ProfilePics" + "\\" + arr[1]));
            }
            else if (e.CommandName == "edt")
            {
                Response.Redirect("Employee_Add.aspx?EmpId=" + e.CommandArgument);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Search");
            cmd.Parameters.AddWithValue("@Search", txtsearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdv1.DataSource = dt;
            grdv1.DataBind();
        }
    }
}

/*select *,convert(varchar(50), DOB,106) as Dateofbirth,convert(varchar(50), Joining_Date,106) as Joindate,convert(varchar(50), Created_On,113) as DateCreated,convert(varchar(50), Modified_On,113) as DateModified from Employee_Profile join tblGender on Gender = GenderID join tblMarital_Status on Marital_Status = MSID join tblBlood_Group on Blood_Group = BGID where Name like '" + txtsearch.Text+"%' and Employee_Profile.Status=0*/