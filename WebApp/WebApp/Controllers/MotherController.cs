using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MotherController : Controller
    {
        
        private readonly MotherDAO _dao = new MotherDAO();
        // GET: Mother
        public ActionResult Index()
        {
            return View(MotherDAO.GetMother());
        }

        // GET: Mother/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mother/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mother/Create
        [HttpPost]
        public ActionResult Create(mother mother)
            //FormCollection collection
        {
            try
            {
                // child1.gender = (int)ViewData["Gender"];
                _dao.CreateMotherData(mother);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }

        // GET: Mother/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mother/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mother/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mother/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
