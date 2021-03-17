using System;
using CommunityEvents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI.HtmlControls;

namespace CommunityEvents
{
    public partial class EventWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetLocalEvents_Click(object sender, EventArgs e)
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

                //if get was successful...
                if (response.IsSuccessStatusCode)
                {
                    dataObjects = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;

                }
                //if GET failed...
                else
                {
                    //TODO error catching

                }

                //iterate through response and populate web page with events

                //declare variables
                int length = dataObjects.Count();
                Event currentEvent = null;
                HtmlTableRow tRow = null;
                HtmlTableCell cTitle = null;
                HtmlTableCell cDateTime = null;
                HtmlTableCell cVenue = null;
                HtmlTableCell cCity = null;
                HtmlTableCell cState = null;
                HtmlTableCell cZip = null;
                HtmlTableCell cDescription = null;

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