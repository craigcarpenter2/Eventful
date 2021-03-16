using System;
using CommunityEvents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CommunityEvents
{
    public partial class EventWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IEnumerable<Event> dataObjects = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44324/api/event");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                //HTTP GET
                HttpResponseMessage response = client.GetAsync("").Result;
              

                if (response.IsSuccessStatusCode)
                {
                    dataObjects = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                    
                }
                else //web api sent error response 
                {
                    //log response status here..

                }
            }
           
            TextBox1.Text = dataObjects.ToString();
        }
    }
}