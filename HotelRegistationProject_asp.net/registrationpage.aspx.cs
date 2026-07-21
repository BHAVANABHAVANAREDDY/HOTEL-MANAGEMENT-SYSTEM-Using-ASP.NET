using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRegistationProject_asp.net
{
    public partial class registrationpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string fname = txtfname.Text;
            string gender = string.Empty;
            if (rbmale.Checked==true)
            {
                gender = rbmale.Text;
            }
            else if (rbfemale.Checked == true)
            {
                gender = rbfemale.Text;
            }
            string languages = string.Empty;
            if (cbenglish.Checked)
            {
                languages = cbenglish.Text;
            }
            if (cbtelugu.Checked == true)
            {
                languages = languages + "," + cbtelugu.Text;
            }
            if (cbhindi.Checked == true)
            {
                languages = languages + " ," + cbhindi.Text;
            }
            string country = ddcountry.Text;
            SqlConnection con = new SqlConnection("data source=BHAVANA\\SQL2025;database=CUSTDB;integrated security=true");
            string query = "insert into userdata values(@fname,@lname,@username,@gender,@password,@confirm,@email,@phone,@address,@age,@languages,@country)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", txtlname.Text);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@confirm", txtconfirm.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@age", txtage.Text);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@languages", languages);
            cmd.Parameters.AddWithValue("@country", country);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Label14.Text = "inserted successfully";
            Response.Redirect("masterpagewebform.aspx");
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("masterpagewebform.aspx");
            
            
        }
    }
}