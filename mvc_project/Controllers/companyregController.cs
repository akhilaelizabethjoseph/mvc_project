using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    public class companyregController : Controller
    {
        mvc_projectEntities dbobj = new mvc_projectEntities();
        // GET: companyreg
        public ActionResult insertcompany_pageload()
        {
            return View();
        }
        public ActionResult insertcompany_click(companyinsert clsobj)
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
                dbobj.sp_companyreg(regid, clsobj.name, clsobj.address, clsobj.phone, clsobj.email, clsobj.status);
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.pass, "company");
                clsobj.msg = "inserted";
                return View("insertcompany_pageload", clsobj);
            }
            return View("insertcompany_pageload", clsobj);
        }
    }
}