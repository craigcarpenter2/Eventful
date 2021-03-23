using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityEvents.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int HomeZip { get; set; }
    }
}