using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Models
{ 
    public partial class Classes
{
    public string Teachername
    {
        get
        {
            if (!TeacherId.HasValue)
            {
                return "";
            }
            CoursemanagerEntities db = new CoursemanagerEntities();
            var teacher = db.teachers.Where(T => T.Id == TeacherId.Value).FirstOrDefault();
            if (teacher == null)
            {
                return "";
            }
            return teacher.Name;
        }
    }
}
}