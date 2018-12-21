using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebAppV2.Models;

namespace WebAppV2.Controllers
{
    public class MotherController : Controller
    {
        // GET: Mother
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        // GET: Child/Edit/5
        public ActionResult Edit(int id)
        {

            mother ma = new mother();

            child cha = new child();
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                cha = ctx.child.Where(ch => ch.child_id == id).FirstOrDefault();

                ma = ctx.mother.Where(m => m.mother_id == cha.mother_id).FirstOrDefault();
                ViewData["child"] = cha.child_id;
                Session["child_id"] = cha.child_id;


            }
            return View(ma);
        }

        // POST: Child/Edit/5
        [HttpPost]
        public ActionResult Edit(mother mother)
        {
           


            try
            {
                MotherDAO.updatemother(mother);

               

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}