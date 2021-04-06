using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityEvents.Models;

namespace CommunityEvents
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            IEnumerable<User> userList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44324/api/user");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                String apiParameter = "";
                //HTTP GET
                HttpResponseMessage response = client.GetAsync(apiParameter).Result;

                //if GET was successful, save response into Event list (dataObjects)
                if (response.IsSuccessStatusCode)
                {
                    userList = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                }
                else
                {
                    LogInServerError.Visible = true;
                }
            }

            foreach(User u in userList)
            {

                if (Username.Text.Equals(u.Username) && Password.Text.Equals(u.Password))
                {
                    Session["Username"] = Username.Text;
                    Session["Password"] = Password.Text;
                    Session["Email"] = u.Email as string;
                    Session["HomeZip"] = u.HomeZip;
                    Session["UserId"] = u.UserId;
                }

                Response.Redirect("~/CommunityEventForm.aspx");
            }

            LogInCredentialError.Visible = true;

            


        }
        protected void NoAccount_Click(object sender, EventArgs e)
        {
            Session["Username"] = "";
            Session["Password"] = "";
            Response.Redirect("~/CommunityEventForm.aspx");
        }
    }
}