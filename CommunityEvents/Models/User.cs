using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommunityEvents.Models
{
    public class User
    {
        //Getters and Setters for each parameter 
        private int uid { get; set; }       //unique numeric identifier

        private string uName { get; set; }     //username

        [Display(Name = "password")]
        private string pwd { get; set; }    //password

        private string email { get; set; }

        [Display(Name = "Home ZIP Code")]
        private int zipH { get; set; }   //home zip code

        public User(int _uid, string _uName, string _pwd, string _email, int _zipH)
        {
            uid = _uid;
            uName = _uName;
            _pwd = pwd;
            _email = email;
            _zipH = zipH;
        }

        //changes user's password
        private int chgPwd(string newPwd)
        {
            pwd = newPwd;
            return 0;
        }

        //changes user's username
        private int chgUName(string newUName)
        {
            uName = newUName;
            return 0;
        }

        //changes user's email
        private int chgEmail(string newEmail)
        {
            email = newEmail;
            return 0;
        }

        //changes user's home zip
        private int chgZIPH(int newZIPH)
        {
            zipH = newZIPH;
            return 0;
        }
    }
}
