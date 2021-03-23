using System;
using CommunityEvents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityEvents
{
    public partial class CreateEventForm : System.Web.UI.Page
    {
        //save the state of date, time, and location here
        DateTime eventDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            eventDate = new DateTime();
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            eventDate = Calendar.SelectedDate;
        }


        //User submits the new event
        protected void Submit_Click(object sender, EventArgs e)
        {
            //add the enterered time to the DateTime object
            /*
            int hours = Int32.Parse(Time.Text.Substring(0,2));
            int minutes = Int32.Parse(Time.Text.Substring(3,2));
            TimeSpan time = new TimeSpan(hours, minutes, 0);
            DateTime eventDateTime = eventDate.Add(time);
            */
            /*
            Event testEvent = new Event()
            {
                Title = "test event",
                Venue = "venue",
                Date = new DateTime(),
                City = "city",
                State = "state",
                Zip = 25510,
                Description = "this is a test for the post method"
            };
            */
            



        }
    }
}