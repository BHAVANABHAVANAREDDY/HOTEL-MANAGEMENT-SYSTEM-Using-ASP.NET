using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRegistationProject_asp.net
{
    public partial class hotelRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var res = Session["name"];
            Label6.Text = $"{res}, Please choose your Room type";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int price = 0;
            int total = 0;
            string type = string.Empty;
            if (rbdeluxe.Checked)
            {
                type = rbdeluxe.Text;
            }
            else if (rbnormal.Checked)
            {
                type = rbnormal.Text;
            }

            string extra = string.Empty;
            if (cbcomputer.Checked)
            {
                extra= cbcomputer.Text;
            }
            if (cbservice.Checked)
            {
                extra = extra +" ,"+ cbservice.Text;
            }
            if(cbcomputer.Checked && cbservice.Checked)
            {
                price = 150;
            }
            else if(!cbcomputer.Checked && cbservice.Checked)
            {
                price = 100;
            }
            else if(cbcomputer.Checked && !cbservice.Checked)
            {
                price = 50;
            }
            else
            {
                price = 0;
            }

            if (rbdeluxe.Checked)
            {
                total = price + 2500;
            }
            else if (rbnormal.Checked)
            {
                total = price + 1200;
            }
            Session["room"] = type;
            Session["extra"] = extra;
            Session["price"] = total;
            Response.Redirect("finalPage.aspx");
        }
    }
}