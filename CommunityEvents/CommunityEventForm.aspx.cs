using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;

namespace CommunityEvents
{
    
    public partial class EventWebForm : System.Web.UI.Page
    {
        int id = 10;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button1_Click1(object sender, EventArgs e)
        {
        
            var name = TextBox1;
            var date = Calendar1;
            var venue = TextBox2;
            var description = TextBox3;
            int idNum = id + 1;
        
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}