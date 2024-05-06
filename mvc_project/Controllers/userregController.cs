using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    public class userregController : Controller
    {
        mvc_projectEntities dbobj = new mvc_projectEntities();
        // GET: userreg
        public ActionResult insertuser_pageload()
        {
            List<stclass> stlist = new List<stclass>
            {
                new stclass{ sid = 1, sname = "kerala" },
                new stclass{ sid = 2, sname = "thamilnadu" },
                new stclass{ sid = 3, sname = "karnataka" }
            };
            ViewBag.selstates = new SelectList(stlist, "sid", "sname");
            userinsert user = new userinsert();
            user.myfavouritequal = getqualificationdata();
            return View(user);
        }
        public List<checkboxlisthelper> getqualificationdata()
        {
            List<checkboxlisthelper> sts = new List<checkboxlisthelper>()
            {
                new checkboxlisthelper{value="sslc",text="sslc",ischecked=true},
                new checkboxlisthelper{value="plustwo",text="plustwo",ischecked=false},
                new checkboxlisthelper{value="bca",text="bca",ischecked=false},
                new checkboxlisthelper{value="mca",text="mca",ischecked=false},
                new checkboxlisthelper{value="btech",text="btech",ischecked=false},


            };
            return sts;
        }
        public ActionResult insertuser_click(userinsert clsobj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_maxidlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/phs");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\phs", fname);
                    clsobj.photo = fullpath;
                }
                List<stclass> stlist = new List<stclass>
            {
                new stclass{ sid = 1, sname = "kerala" },
                new stclass{ sid = 2, sname = "thamilnadu" },
                new stclass{ sid = 3, sname = "karnataka" }
            };
                int selectedid = Convert.ToInt32(form["selstates"]);
                stclass selecteditem = stlist.FirstOrDefault(c => c.sid == selectedid);
                clsobj.sid = selecteditem.sid;
                clsobj.sname = selecteditem.sname;
                ViewBag.selstates = new SelectList(stlist, "sid", "sname");
                var quid = string.Join(",", clsobj.selectedqual);
                clsobj.qual = quid;
                clsobj.myfavouritequal = getqualificationdata();
                dbobj.sp_userreg(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.sname, clsobj.qual, clsobj.skills, clsobj.expe, clsobj.photo, clsobj.status);
                dbobj.sp_logininsert(regid, clsobj.una, clsobj.pwd, "user");
                clsobj.msg = "inserted";
                return View("insertuser_pageload",clsobj);


            }
            return View("insertuser_pageload",clsobj);
        }
    }
}
