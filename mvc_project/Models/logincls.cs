using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_project.Models
{
    public class logincls
    {

        [Required(ErrorMessage = "enter username")]
        public string uname { set; get; }
        [Required(ErrorMessage = "enter password")]
        public string password { set; get; }
        public string msg { set; get; }
        public string ltype { set; get; }
    }
}