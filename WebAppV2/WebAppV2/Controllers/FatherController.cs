using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppV2.Models;

namespace WebAppV2.Controllers
{
    public class FatherController : Controller
    {
        // GET: Father
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // GET: Child/Edit/5
        public ActionResult Edit(int id)
        {

            father fa = new father();
            child cha = new child();
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                cha = ctx.child.Where(ch => ch.child_id == id).FirstOrDefault();

                 fa = ctx.father.Where(f => f.father_id == cha.father_id).FirstOrDefault();
                ViewData["child"] = cha.child_id;
                Session["child_id"] = cha.child_id;


            }
            return View(fa);
        }

        // POST: Child/Edit/5
        [HttpPost]
        public ActionResult Edit(father father)
        {
            try
            {
                FatherDAO.updatefather(father);           
                return View();
            }
            catch
            {
              return View();
            }
        }

        public ActionResult IndexProfile(string username)
        {
           
            father father = new father();
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                father = (from a in ctx.father where a.father_login == username select a).FirstOrDefault();

            }
            return View(father);
        }

        public ActionResult GetChilds(int father_id)
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                List<child> mlist = new List<child>();
                father fa = new father();
                mlist = ctx.child.Where(cha => cha.father_id == father_id).ToList();
                return View(mlist);
            }
        }


    }
}
