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
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            if (txtnewpw.Text == txtconfirmpw.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "ChangePassword");
                cmd.Parameters.AddWithValue("@NewPassword", txtnewpw.Text);
                cmd.Parameters.AddWithValue("@ID", Session["ID"]);
                cmd.Parameters.AddWithValue("@CurrentPassword", txtcurrentpw.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                lblalert.Text = "Your password has been changed sucessfully!!";
            }
            else
            {
                lblalert.Text = "Current password does not match!!";
            }
        }
    }
}