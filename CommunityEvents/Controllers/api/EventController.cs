using CommunityEvents.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CommunityEvents.Controllers.api
{
    public class EventController : ApiController
    {
        static JavaScriptSerializer serial = new JavaScriptSerializer();
        // Pulls serialized list of events from text file.

        static string eventDataDirectory = HttpContext.Current.Server.MapPath("/Data/Event.txt");
        static string serializedEvents;// = System.IO.File.ReadAllText(eventDataDirectory); 
        List<Event> events = getEventList();


       

        /*
        //List containing events in different zip codes
        List<Event> hardcodedEvents = new List<Event>()
        {
          new Event(){Id = 0, UserId = 0, Title = "fun event", City = "Huntington", State = "WV",
              Zip = 25701, Latitude=38.39878030293934, Longitude=-82.45671764403089, Date = DateTime.Today.AddDays(5), Venue = "CTC",
              Description =  "Church Service"},

          new Event(){Id = 1, UserId = 0, Title = "Craft Festival", City = "Huntington", State = "WV",
              Zip = 25504, Latitude=38.38968486402137, Longitude=-82.30144616703348, Date = DateTime.Today.AddDays(20), Venue = "Barboursville Park",
              Description =  "Festival of crafts"},

          new Event(){Id = 2, UserId = 1, Title = "Country Concert", City = "Charleston", State = "WV",
              Zip = 25302, Latitude=38.35613520440844, Longitude=-81.63998837286755, Date = DateTime.Today.AddDays(8), Venue = "Charleston Civic Center",
              Description =  "Local Country Concert"},

          new Event(){Id = 3, UserId = 2, Title = "Play", City = "Ashland", State = "KY",
              Zip = 41101, Latitude=38.480311047866515, Longitude=-82.64287003238847, Date = DateTime.Today.AddDays(90), Venue = "Paramount",
              Description =  "Wicked the play"},

          new Event(){Id = 4, UserId = 3, Title = "State Fair", City = "Ashland", State = "KY",
              Zip = 41101, Latitude=38.48221719562341, Longitude=-82.63906132080415,Date = DateTime.Today.AddDays(5), Venue = "Ashland Riverfront",
              Description =  "State Fair"},

          new Event(){Id = 5, UserId = 3, Title = "Yoga in the park", City = "Huntington", State = "WV",
              Zip = 25705, Latitude=38.407348161450884, Longitude=-82.43801454403074, Date = DateTime.Today.AddDays(20), Venue = "Ritter Park",
              Description =  "Yoga"},

          new Event(){Id = 6, UserId = 3, Title = "Baseball Game", City = "Charleston", State = "WV",
              Zip = 25302, Latitude=38.34924540224724, Longitude=-81.62489628821137, Date = DateTime.Today.AddDays(25), Venue = "Appalachian Power Park",
              Description =  "Baseball Game"},

          new Event(){Id = 7, UserId = 4, Title = "Pumpkin Festival", City = "Milton", State = "WV",
              Zip = 25541, Latitude=38.430538393986446, Longitude=-82.13123816122527, Date = DateTime.Today.AddDays(240), Venue = "CTC",
              Description =  "WV Pumpkin Festival"},
        };
        */

       

        public static List<Event> getEventList()
        {
            string serializedEvents = System.IO.File.ReadAllText(eventDataDirectory); // I don't know what the path should be
            return serial.Deserialize<List<Event>>(serializedEvents);
        }

        [HttpPost]
        [Route ("api/Event/PostNewEvent")]
        public IHttpActionResult PostNewEvent(Event newEvent){

            
            
            
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            events.Add(new Event
            {
                Id = newEvent.Id,
                UserId = newEvent.UserId,
                Title = newEvent.Title,
                City = newEvent.City,
                State = newEvent.State,
                Zip = newEvent.Zip,
                Latitude = newEvent.Latitude,
                Longitude = newEvent.Longitude,
                Date = newEvent.Date,
                Venue = newEvent.Venue,
                Description = newEvent.Description
            }) ;

            //save changes to file
            serializedEvents = serial.Serialize(events);
            File.WriteAllText(eventDataDirectory, serializedEvents);

            events = getEventList();

            return Ok();
        }

        [HttpPost]
        public Boolean AddEventDetails(int id, int userId, string title, string city,
            string state, long zip, double latitude, double longitude, DateTime date, string venue, string description)
        {
            
            
            events.Add(new Event
            {
                Id = id,
                UserId = userId,
                Title = title,
                City = city,
                State = state,
                Zip = zip,
                Latitude = latitude,
                Longitude = longitude,
                Date = date,
                Venue = venue,
                Description = description
            });
            //print event details to make sure its working??

            return true;
             

        }

        //Accesses all events
        [HttpGet]
        public List<Event> GetAllEventDetails()
        {
            var eventsList = new List<Event>();
            eventsList.AddRange(events);
            return eventsList;

        }
        
        //Method to access events based on their Zip Code
        [HttpGet]
        public List<Event> GetLocalEventDetails(long Zip)
        {
             var eventsList = new List<Event>();
             var localEvents = events.Where(evt => evt.Zip == Zip);
             eventsList.AddRange(localEvents);
             return eventsList;
        }
        
        /*
        [HttpGet]
        public List<Event> GetEventDetails(int Id)
        {
            var eventsList = new List<Event>();
            var localEvents = events.Where(evt => evt.Id == Id);
            eventsList.AddRange(localEvents);
            return eventsList;
           // return ("Event Details");

        }
        */

        [HttpGet]
        public List<Event> GetUserEvents(String Username, int UserId)
        {
            var eventsList = new List<Event>();
            var userEvents = events.Where(evt => evt.UserId == UserId);
            eventsList.AddRange(userEvents);
            return eventsList;
            // return ("Event Details");

        }


        [HttpDelete]
        public string DeleteEventDetails(int Id)
        {
            return "Event details deleted having Id: " + Id;

        }

        [HttpPut]
        public string UpdateEventDetails(string Title, int Id, string City, 
            string State, long Zip, double Latitude, double Longitude, DateTime Date, string Venue, string Description)
        {
            return "Event details Updated with Title: " + Title + ", Id: " + Id + 
                ", City: " + City + ", State: " + State + ", Zip: " + Zip + ", Date: " 
                + Date + ", Venue: " + Venue + ", Description: " + Description;
                        

        }
    }
}
