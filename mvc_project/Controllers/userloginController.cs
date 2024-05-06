using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    public class userloginController : Controller
    {
        mvc_projectEntities dbobj = new mvc_projectEntities();
        // GET: userlogin
        public ActionResult login_pageload()
        {
            return View();
        }
        public ActionResult userhome()
        {
            return View();
        }
        public ActionResult companyhome()
        {
            return View();
        }
        public ActionResult login_click(logincls objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(objcls.uname, objcls.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginid(objcls.uname, objcls.password).FirstOrDefault();
                    Session["uid"] = uid;
                    var lt = dbobj.sp_logintype(objcls.uname, objcls.password).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("userhome");
                    }
                    else if (lt == "company")
                    {
                        return RedirectToAction("companyhome");
                    }



                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "invalid login";
                    return View("login_pageload", objcls);
                }
            }
            return View("login_pageload", objcls);
        }
    }
}