using CommunityEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CommunityEvents
{
    public partial class UserProfile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/LogIn.aspx");
            }
            
            WelcomeMessage.Text = "Welcome Back, " + Session["Username"] as string;


            IEnumerable<Event> dataObjects = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44324/api/event/");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                String apiParameter = "?Username="+Session["Username"] as string +"&UserId=" + Session["UserId"] as string;
                //HTTP GET
                HttpResponseMessage response = client.GetAsync(apiParameter).Result;

                //if GET was successful, save response into Event list (dataObjects)
                if (response.IsSuccessStatusCode)
                {
                    dataObjects = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                }

                //declare variables
                Event currentEvent = null;
                HtmlTableRow tRow = null;
                HtmlTableCell cTitle = null;
                HtmlTableCell cDateTime = null;
                HtmlTableCell cVenue = null;
                HtmlTableCell cCity = null;
                HtmlTableCell cState = null;
                HtmlTableCell cZip = null;
                HtmlTableCell cDescription = null;

                //if GET failed...
                int length;
                if (dataObjects == null)
                {
                    return;
                }

                //iterate through response Events list and populate web page with events
                else
                {
                    length = dataObjects.Count();
                }
                for (int i = 0; i < length; i++)
                {
                    //create new empty row and cells
                    tRow = new HtmlTableRow();
                    cTitle = new HtmlTableCell();
                    cDateTime = new HtmlTableCell();
                    cVenue = new HtmlTableCell();
                    cCity = new HtmlTableCell();
                    cState = new HtmlTableCell();
                    cZip = new HtmlTableCell();
                    cDescription = new HtmlTableCell();

                    //populate new cells with data about one event
                    currentEvent = dataObjects.ElementAt(i);
                    cTitle.InnerText = currentEvent.Title;
                    cDateTime.InnerText = currentEvent.Date.ToString();
                    cVenue.InnerText = currentEvent.Venue;
                    cCity.InnerText = currentEvent.City;
                    cState.InnerText = currentEvent.State;
                    cZip.InnerText = currentEvent.Zip.ToString();
                    cDescription.InnerText = currentEvent.Description;

                    //add these cells to the current row
                    tRow.Controls.Add(cTitle);
                    tRow.Controls.Add(cDateTime);
                    tRow.Controls.Add(cVenue);
                    tRow.Controls.Add(cCity);
                    tRow.Controls.Add(cState);
                    tRow.Controls.Add(cZip);
                    tRow.Controls.Add(cDescription);

                    //add the current row to the display table
                    ResultTable.Rows.Add(tRow);
                }
            }



        }
    }
}