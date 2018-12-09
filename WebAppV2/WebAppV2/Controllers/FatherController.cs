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

            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                 fa = ctx.father.Where(f => f.father_id == id).FirstOrDefault();

            }
            return View(fa);
        }

        // POST: Child/Edit/5
        [HttpPost]
        public ActionResult Edit(father father)
        {
            father fa = new father();
        

            try
            {
                FatherDAO.updatefather(fa);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}