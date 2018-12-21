using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppV2.Models;

namespace WebAppV2.Controllers
{
    public class ParentController : Controller
    {
        // GET: Parent
        public ActionResult Index(string username)
        {
            mother mother = new mother();
            father father = new father();
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                mother = (from a in ctx.mother where a.mother_login == username select a).FirstOrDefault();
                
            }
             return View(mother);
        }

        public ActionResult GetChilds(int mother_id)
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                List<child> mlist = new List<child>();
                mother ma = new mother();
                mlist = ctx.child.Where(cha => cha.mother_id == mother_id).ToList();
                return View(mlist);
            }
        }


    }


}