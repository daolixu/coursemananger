using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace course_manage.Controllers
{
    public class HomeController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();
        public ActionResult Index()
        {
            return View();
        }   

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        
        public ActionResult SideBar()
        {
            var sidebars = db.Sidebar.ToList();
            ViewBag.SideBars = sidebars;
            return PartialView("~/Views/Shared/SideBar.cshtml");
        }
        public ActionResult Navbar()
        {
            var site = new Websiteinfo();
            ViewBag.site = site;
            site.Actionlinks = db.Actionlink.ToList();
            return PartialView("~/Views/Shared/Navbar.cshtml");
        }
    }
}
