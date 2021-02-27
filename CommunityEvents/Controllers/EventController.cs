using CommunityEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommunityEvents.Controllers
{
    public class EventController : ApiController
    {
        //List containing events in different zip codes
        List<Event> events = new List<Event>()
        {
          new Event(){Id = 0, Title = "fun event", City = "Huntington", State = "WV",
              Zip = 25705, Date = DateTime.Today.AddDays(5), Venue = "CTC",
              Description =  "Church Service"},

          new Event(){Id = 1, Title = "Craft Festival", City = "Huntington", State = "WV",
              Zip = 25504, Date = DateTime.Today.AddDays(20), Venue = "Barboursville Park",
              Description =  "Festival of crafts"},

          new Event(){Id = 2, Title = "Country Concert", City = "Charleston", State = "WV",
              Zip = 25302, Date = DateTime.Today.AddDays(8), Venue = "Charleston Civic Center",
              Description =  "Local Country Concert"},

          new Event(){Id = 3, Title = "Play", City = "Ashland", State = "KY",
              Zip = 41101, Date = DateTime.Today.AddDays(90), Venue = "Paramount",
              Description =  "Wicked the play"},

          new Event(){Id = 4, Title = "State Fair", City = "Ashland", State = "KY",
              Zip = 41101, Date = DateTime.Today.AddDays(5), Venue = "Ashland Riverfront",
              Description =  "State Fair"},

          new Event(){Id = 5, Title = "Yoga in the park", City = "Huntington", State = "WV",
              Zip = 25705, Date = DateTime.Today.AddDays(20), Venue = "Ritter Park",
              Description =  "Yoga"},

          new Event(){Id = 6, Title = "Baseball Game", City = "Charleston", State = "WV",
              Zip = 25302, Date = DateTime.Today.AddDays(25), Venue = "Appalachian Power Park",
              Description =  "Baseball Game"},

          new Event(){Id = 7, Title = "Pumpkin Festival", City = "Milton", State = "WV",
              Zip = 25541, Date = DateTime.Today.AddDays(240), Venue = "CTC",
              Description =  "WV Pumpkin Festival"},
        };

        [HttpPost]
        public Boolean AddEventDetails(int id, string title, string city,
            string state, long zip, DateTime date, string venue, string description)
        {
            
            var eventsList = new List<Event>();
            
            eventsList.Add(new Event
            {
                Id = id,
                Title = title,
                City = city,
                State = state,
                Zip = zip,
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
        
        /**
        [HttpGet]
        public List<Event> GetEventDetails(int Id)
        {
            var eventsList = new List<Event>();
            var localEvents = events.Where(evt => evt.Id == Id);
            eventsList.AddRange(localEvents);
            return eventsList;
           // return ("Event Details");

        }
        **/

        [HttpDelete]
        public string DeleteEventDetails(int Id)
        {
            return "Event details deleted having Id: " + Id;

        }

        [HttpPut]
        public string UpdateEventDetails(string Title, int Id, string City, 
            string State, long Zip, DateTime Date, string Venue, string Description)
        {
            return "Event details Updated with Title: " + Title + ", Id: " + Id + 
                ", City: " + City + ", State: " + State + ", Zip: " + Zip + ", Date: " 
                + Date + ", Venue: " + Venue + ", Description: " + Description;
                        

        }

       
        

    }
}
