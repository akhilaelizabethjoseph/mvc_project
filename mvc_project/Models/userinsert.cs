using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_project.Models
{
    
    
        public class stclass
        {
            public int sid { set; get; }
            public string sname { set; get; }
        }
        public class checkboxlisthelper
        {
            public string value { set; get; }
            public string text { set; get; }
            public bool ischecked { set; get; }
        }
        public class userinsert
        {
            public int sid { set; get; }
            public string sname { set; get; }
            public List<checkboxlisthelper> myfavouritequal { set; get; }
            public string[] selectedqual { set; get; }

            [Required(ErrorMessage = "enter name")]
            public string name { set; get; }
            [Range(18, 50, ErrorMessage = "enter age")]
            public int age { set; get; }
            public string address { set; get; }
            [EmailAddress(ErrorMessage = "enter correct mail id")]
            public string email { set; get; }
           
            public string state { set; get; }
            public string qual { set; get; }
            public string skills { set; get; }
            public int expe { set; get; }
            public string photo { set; get; }
            public string status { set; get; }
            [Required(ErrorMessage ="enter username")]
            public string una { set; get; }
            public string pwd { set; get; }
            [Compare("pwd", ErrorMessage = "password missmatch")]
            public string cpwd { set; get; }
            public string msg { set; get; }
        }
    }


