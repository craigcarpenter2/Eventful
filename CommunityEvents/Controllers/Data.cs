using CommunityEvents.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CommunityEvents.Controllers
{
    public class Data
    {
        public void SaveEvents(List<Event> events)
        {
            if (events is null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            TextWriter tw = new StreamWriter("EventsDatabase.txt");

            foreach (Event e in events)
            {
                tw.WriteLine(e.Id);
                tw.WriteLine(e.Title);
                tw.WriteLine(e.City);
                tw.WriteLine(e.State);
                tw.WriteLine(e.Zip);
                tw.WriteLine(e.Date);
                tw.WriteLine(e.Venue);
                tw.WriteLine(e.Description);
            }
        }

        public List<Event> LoadEvents()
        {
            List<Event> events = new List<Event>();

            List<String> content = new List<String>();
            String str;

            TextReader tr = new StreamReader("EventsDatabase.txt");

            while ((str = tr.ReadLine()) != null)
            {
                // Read the 8 variables for the Event from the file
                content.Add(str);
                content.Add(str);
                content.Add(str);
                content.Add(str);
                content.Add(str);
                content.Add(str);
                content.Add(str);
                content.Add(str);

                // Need to add Event constructor
                // Creates new Event and adds to list using the 8 variables from the file.
                events.Add(new Event(content[0], content[1], content[2], content[3], content[4], content[5], content[6], content[7]));

                // Clear content.
                content.Clear();
            }
            return events;
        }

    }
}