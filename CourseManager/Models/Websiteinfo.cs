using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Models
{
    public class Websiteinfo
    {

        public const string SiteName = "课程管理系统";
        public List<Actionlink> Actionlinks { get; set; }

        public Websiteinfo()
        {
            
                CoursemanagerEntities db = new CoursemanagerEntities();
                Actionlinks = db.Actionlink.ToList();
        }
    }
} 