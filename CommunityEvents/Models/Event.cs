using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityEvents.Models
{
    public class Event
    {
        //Getters and Setters for each parameter 
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

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
        
        

        
    }
}