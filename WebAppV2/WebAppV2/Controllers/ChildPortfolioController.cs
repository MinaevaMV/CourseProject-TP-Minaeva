using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppV2.Models;

namespace WebAppV2.Controllers
{
    public class ChildPortfolioController : Controller
    {
        // GET: ChildPortfolio
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // GET: Child/Edit/5
        public ActionResult Edit(int id)
        {
            child_portfolio chp = new child_portfolio();
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
               chp = ctx.child_portfolio.Where(cp => cp.child_id == id).FirstOrDefault();
                child ch = ctx.child.Where(c => c.child_id == id).FirstOrDefault();
                string fio = ch.child_surname + " " + ch.child_name + " " + ch.child_patronymic;
                ViewData["fio"] = fio;

            }
            return View(chp);
        }

        // POST: Child/Edit/5
        [HttpPost]
        public ActionResult Edit(child_portfolio cp)
        {
            try
            {
                ChildportfolioDAO.UpdatePortfolio(cp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
