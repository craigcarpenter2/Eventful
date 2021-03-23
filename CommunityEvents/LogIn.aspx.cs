using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityEvents
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Username"] = Username.Text;
            Session["Password"] = Password.Text;
            Response.Redirect("~/CommunityEventForm.aspx");

            Session["UserId"] = 0;
            Session["HomeZip"] = 25510;
            Session["Email"] = "shoemaker30@marshall.edu";
        }
        protected void NoAccount_Click(object sender, EventArgs e)
        {
            Session["Username"] = "";
            Session["Password"] = "";
            Response.Redirect("~/CommunityEventForm.aspx");
        }
    }
}