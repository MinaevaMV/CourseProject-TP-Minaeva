using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppV2.Models;

namespace WebAppV2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexGroup(string username)
        {
            group group = new group();
            teacher teacher = new teacher();
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                teacher = (from a in ctx.teacher where a.teacher_login == username select a).FirstOrDefault();
                string query = string.Format("select * from [group]  where group_id={0}", teacher.teacher_group_id);

               
                group = ctx.Database.SqlQuery<group>(query).FirstOrDefault();
            }


            return View(group);
        }
    }
}