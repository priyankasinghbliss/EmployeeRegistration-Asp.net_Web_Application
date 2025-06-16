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
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-FG2CMD4N\\SQLEXPRESS;initial catalog=DBEmployeeRegistration;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Joinone");
            cmd.Parameters.AddWithValue("@ID", Session["ID"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdv.DataSource = dt;
            grdv.DataBind();
            if (Session["ID"] != null)
            {
                lblname.Text = Convert.ToString(dt.Rows[0]["First_Name"]);
            }
        }
    }
}