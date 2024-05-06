using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_project.Models
{
    public class companyinsert
    {
        [Required(ErrorMessage ="enter name")]
        public string name { set; get; }
        [Required(ErrorMessage ="enter address")]
        public string address { set; get; }
        [Required(ErrorMessage = "enter phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "enter valid number")]
        public string phone { set; get; }
        [EmailAddress(ErrorMessage = "enter valid mailid")]
        public string email { set; get; }
        public string status { set; get; }
        [Required(ErrorMessage ="enter username")]
        public string username { set; get; }
        public string pass { set; get; }
        [Compare("pass", ErrorMessage = "password missmatch")]
        public string cpassword { set; get; }
        public string msg { set; get; }
    }
}