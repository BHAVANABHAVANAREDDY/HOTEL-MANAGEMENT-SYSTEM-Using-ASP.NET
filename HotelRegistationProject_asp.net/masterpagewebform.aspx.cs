using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRegistationProject_asp.net
{
    public partial class masterpagewebform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistration_Click(object sender, EventArgs e)
        {
            
            Server.Transfer("registrationpage.aspx");

            
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            SqlConnection con = new SqlConnection("data source=BHAVANA\\SQL2025;database=CUSTDB;integrated security=true");
            string query = "select count(*) from userdata where username=@username and password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            con.Open();
            int count=(int)cmd.ExecuteScalar();
            con.Close();
            if (count == 1)
            {
                Session["name"] = txtusername.Text;
                Response.Redirect("loggedPage.aspx");
            }
            else
            {
                Label4.Text = "invalid username or password";
            }
        }
    }
}