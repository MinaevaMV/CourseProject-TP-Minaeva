using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppV2.Models;

namespace WebAppV2.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                var list = ctx.report.ToList();
                return View(list);
            }

        }

        // GET: Report
        public ActionResult IndexById(int author_id)
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                var list = (from a in ctx.report where a.author_id == author_id select a).ToList();


                string query = "select s.* from superintendent s inner join report r on r.auditor_id=s.id_superintendent";
                List<superintendent> mlist = ctx.Database.SqlQuery<superintendent>(query).ToList();
                foreach (superintendent el in mlist)
                {
                    el.fio = el.superintendent_surname + " " + el.superintendent_name + " " + el.superintendent_patronymic;
                }
                ViewData["superintendentFIO"] = mlist;

                //string query = "select m.* from methodist m inner join report r on r.author_id=m.methodist_id";
                //List<methodist> mlist = ctx.Database.SqlQuery<methodist>(query).ToList();
                //foreach (methodist el in mlist)
                //{
                //    el.fio = el.methodist_name + " " + el.methodist_surname + " " + el.methodist_patronymic;
                //}
                //ViewData["methodistFIO"] = mlist;
                return View(list);
            }

        }
        public ActionResult IndexByUser(string username)
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                var met = (from a in ctx.methodist where a.methodist_login == username select a).FirstOrDefault();
                int id = met.methodist_id;
                var list = (from a in ctx.report where a.author_id == id select a).ToList();
                string query = "select s.* from superintendent s inner join report r on r.auditor_id=s.id_superintendent";
                List<superintendent> mlist = ctx.Database.SqlQuery<superintendent>(query).ToList();
                foreach (superintendent el in mlist)
                {
                    el.fio = el.superintendent_surname + " " + el.superintendent_name + " " + el.superintendent_patronymic;
                }
                ViewData["superintendentFIO"] = mlist;
                return View(list);
            }

        }

        public ActionResult IndexBySupUser(string username)
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                var sup = (from a in ctx.superintendent where a.superintendent_login == username select a).FirstOrDefault();
                int id = sup.id_superintendent;
                var list = (from a in ctx.report where a.auditor_id == id && a.sended == "sent for checking" select a).ToList();
                string query = "select m.* from methodist m inner join report r on r.author_id=m.methodist_id where r.sended = 'sent for checking'";
                List<methodist> mlist = ctx.Database.SqlQuery<methodist>(query).ToList();
                foreach (methodist el in mlist)
                {
                    el.fio = el.methodist_name + " " + el.methodist_surname + " " + el.methodist_patronymic;
                }
                ViewData["methodistFIO"] = mlist;
                return View(list);
            }

        }


        [HttpGet]
        public ActionResult Create()
        {
            report rep = new report();

            methodist met = new methodist();
            superintendent sup = new superintendent();

            using (kindergartenEntities db = new kindergartenEntities())
            {
                rep.suplist = db.superintendent.ToList();
                rep.metlist = db.methodist.ToList();


                foreach (superintendent el in rep.suplist)
                {
                    el.fio = el.superintendent_surname + " " + el.superintendent_name + " " + el.superintendent_patronymic;
                }
                foreach (methodist el in rep.metlist)
                {
                    el.fio = el.methodist_surname + " " + el.methodist_name + " " + el.methodist_patronymic;
                }


            }

            return View(rep);
        }


        [HttpPost]
        public ActionResult Create(report rep)
        {

            //ReportDAO.CreateReport(rep);
            using (kindergartenEntities db = new kindergartenEntities())
            {

                db.report.Add(rep);
                db.SaveChanges();
                string query = "select report_id from report where author_id = @P0 and auditor_id=@P1 and Convert(varchar(max),[text]) = @P2 ";
                int idrep = db.Database.SqlQuery<int>(query, new object[] { rep.author_id.ToString(), rep.auditor_id.ToString(), rep.text }).FirstOrDefault();
                return RedirectToAction("ReportSent", new { id = idrep });
            }
            
            

        }

        [HttpGet]
        // GET: Child/Edit/5
        public ActionResult ReportSent(int id)
        {

            report rep = new report();

            using (kindergartenEntities ctx = new kindergartenEntities())
            {

                rep = ctx.report.Where(r => r.report_id == id).FirstOrDefault();

            }
            TempData["report"] = rep;
            TempData.Keep();
            return View(rep);
        }

        // POST: Child/Edit/5
        [HttpPost]
        public ActionResult ReportSent(report report)
        {
            ReportDAO.UpdateStatus(TempData["report"] as report);
            return RedirectToAction("IndexById", new { (TempData["report"] as report).author_id });
        }

        [HttpGet]
        // GET: Child/Edit/5
        public ActionResult ReportCheck(int id)
        {

            report rep = new report();

            using (kindergartenEntities ctx = new kindergartenEntities())
            {

                rep = ctx.report.Where(r => r.report_id == id).FirstOrDefault();

            }
            TempData["report"] = rep;
            TempData.Keep();
            return View(rep);
        }

        // POST: Child/Edit/5
        [HttpPost]
        public ActionResult ReportCheck(report report)
        {
            ReportDAO.UpdateChecking(TempData["report"] as report);
            return RedirectToAction("IndexBySupUser", new { username = User.Identity.Name });
        }

        [HttpGet]
        // GET: Child/Edit/5
        public ActionResult ReportComment(int id)
        {

            report rep = new report();

            using (kindergartenEntities ctx = new kindergartenEntities())
            {

                rep = ctx.report.Where(r => r.report_id == id).FirstOrDefault();

            }
            TempData["report"] = rep;
            TempData.Keep();
            return View(rep);
        }

        // POST: Child/Edit/5
        [HttpPost]
        public ActionResult ReportComment(report report)
        {
            ReportDAO.UpdateComment(TempData["report"] as report, report.comment);
            return RedirectToAction("IndexBySupUser", new{username = User.Identity.Name});
        }

    }
}