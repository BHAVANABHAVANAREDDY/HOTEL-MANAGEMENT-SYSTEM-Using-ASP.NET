using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRegistationProject_asp.net
{
    public partial class finalPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var res = Session["room"];
            var extra = Session["extra"];
            var price = Session["price"];
            var name=Session["name"];
            Label8.Text = $" Your reservation has been confirmed successfully.";
            Label2.Text = $" Your Name: {name}";
            Label3.Text = $" Your Room Type : {res}";
            Label4.Text = $" Your Extra Facilities : {extra}";
            Label5.Text = $" Total Price of Your Room : {price}";
            Label6.Text = $" We appreciate your trust in our hotel and look forward to serving you.";
            Label7.Text = $" Wish you a pleasant and enjoyable stay!";
        }

        
    }
}