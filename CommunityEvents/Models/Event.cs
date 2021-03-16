using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityEvents.Models
{
    public class Event
    {
        //Getters and Setters for each parameter 

        public int Id { get; set; }

        [Required]
        [Display(Name= "Event Name")]
        public string Title { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public long Zip { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        public string Description { get; set; }

        public Event(int id, string title, string city, string state, long zip, DateTime date, string venue, string description)
        {
            Id = id;
            Title = title;
            City = city;
            State = state;
            Zip = zip;
            Date = date;
            Venue = venue;
            Description = description;
        }

        public Event()
        {
        }
    }
}