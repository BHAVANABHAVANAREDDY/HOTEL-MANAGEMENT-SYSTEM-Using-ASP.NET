using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRegistationProject_asp.net
{
    public partial class loggedPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }
        }

        private void getdata()
        {
            var response = Session["name"].ToString();
            lblusername.Text = "WELCOME " + response;
            SqlConnection con = new SqlConnection("data source=BHAVANA\\SQL2025;database=CUSTDB;integrated security=true");
            string query = "select * from userdata where username=@username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", response);
            con.Open();
            var dr = cmd.ExecuteReader();

            GridView1.DataSource = dr;
            GridView1.DataBind();
            con.Close();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            var fname = (TextBox)row.FindControl("TextBox2");
            var lname = (TextBox)row.FindControl("TextBox3");
            var username = (Label)row.FindControl("TextBox1");
            var gender = (TextBox)row.FindControl("TextBox4");
            var password = (Label)row.FindControl("TextBox5");
            var confirm = (Label)row.FindControl("TextBox6");
            var email = (TextBox)row.FindControl("TextBox7");
            var phone = (TextBox)row.FindControl("TextBox8");
            var address = (TextBox)row.FindControl("TextBox9");
            var age = (TextBox)row.FindControl("TextBox10");
            var languages = (TextBox)row.FindControl("TextBox11");
            var country = (TextBox)row.FindControl("TextBox12");
            SqlConnection con = new SqlConnection("data source=BHAVANA\\SQL2025;database=CUSTDB;integrated security=true");
            string query = "update userdata set fname=@fname,lname=@lname,gender=@gender," +
                "email=@email,phone=@phone,address=@address,age=@age,languages=@languages,country=@country";
            SqlCommand cmd = new SqlCommand(query, con);
            
            cmd.Parameters.AddWithValue("@fname", fname.Text);
            cmd.Parameters.AddWithValue("@lname", lname.Text);
            cmd.Parameters.AddWithValue("@gender", gender.Text);
            
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@phone", phone.Text);
            cmd.Parameters.AddWithValue("@address", address.Text);
            cmd.Parameters.AddWithValue("@age", age.Text);
            cmd.Parameters.AddWithValue("@languages", languages.Text);
            cmd.Parameters.AddWithValue("@country", country.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            getdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getdata();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("hotelRegistration.aspx");
        }
    }
}