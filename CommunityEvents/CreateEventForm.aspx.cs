using System;
using CommunityEvents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http.Headers;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace CommunityEvents
{
    public partial class CreateEventForm : System.Web.UI.Page
    {
        

        //save the state of date, time, and location here
        DateTime eventDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/LogIn.aspx");
            }
            if (Session["Username"].Equals(""))
            {
                MyProfileLink.Attributes.Add("style", "display:none");
            }



            eventDate = new DateTime();
            ErrorMessage.Visible = false;
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            eventDate = Calendar.SelectedDate;
        }


        //User submits the new event
        protected void Submit_Click(object sender, EventArgs e)
        {
            //add the enterered time to the DateTime object
            
            int hours = Int32.Parse(Time.Text.Substring(0, 2));
            int minutes = Int32.Parse(Time.Text.Substring(3, 2));
            TimeSpan time = new TimeSpan(hours, minutes, 0);
            DateTime eventDateTime = eventDate.Add(time);


            //api
            string state = null;
            string city = null ;
            int zip = -1;

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://api.bigdatacloud.net/data/");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                String apiParameter = "reverse-geocode-client?latitude=" + Latitude.Text + "&longitude=" + Longitude.Text + "&localityLanguage=en";
                HttpResponseMessage response = client.GetAsync(apiParameter).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    JObject data = (JObject)JsonConvert.DeserializeObject(result);

                    state = data["principalSubdivision"].Value<string>();
                    city = data["city"].Value<string>();
                    zip = data["postcode"].Value<int>();
                }

                else
                {
                    //api call failed, so cant make event
                    ErrorMessage.Visible = true;
                    return;
                }
            }



            int userId = -1;
            if (Session["UserId"] != null)
            {
                userId = (int)Session["UserId"];
            }


            Event newEvent = new Event()
            {
                Id = 1,
                UserId = userId,
                Title = Title.Text,
                Venue = Venue.Text,
                City = city,
                State = state,
                Zip = Convert.ToInt64(zip),
                Latitude = Double.Parse(Latitude.Text),
                Longitude = Double.Parse(Longitude.Text),
                Date = eventDateTime,
                Description = Description.Text
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44324/");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));



                var response = client.PostAsJsonAsync("api/Event/PostNewEvent", newEvent).Result;



            }
        }
    }
}