using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ChildController : Controller
    {
        private readonly ChildDAO _dao = new ChildDAO();
        // GET: Child
        public ActionResult Index()
        {
            return View(ChildDAO.GetChild());
        }


        // GET: Child/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            child child_model = new child();

            mother mothermodel = new mother();
            //  mothermodel.fio = mothermodel.mother_name + " " + mothermodel.mother_surname + " " + mothermodel.mother_patronymic;

            using (kindergartenEntities2 db = new kindergartenEntities2())
            {
                child_model.momnameslist = db.mother.ToList<mother>();
                foreach (mother el in child_model.momnameslist)
                {
                    el.fio = el.mother_name + " " + el.mother_surname + " " + el.mother_patronymic;
                }
            }

            return View(child_model);



            //using (kindergartenEntities1 entities = new kindergartenEntities2())
            //{
            //    child_model.genderlist = entities.child.ToList<child>();
            //}

        //    List<SelectListItem> listItems = new List<SelectListItem>();
        //    listItems.Add(new SelectListItem()
        //    {
        //        Value = "Male",
        //        Text = "Male"
        //    });
        //    listItems.Add(new SelectListItem()
        //    {
        //        Value = "Female",
        //        Text = "Female"
        //    });

 
        //ViewData["gender"] = listItems; 

        //    return View();

        }

        
        [HttpPost]
        public ActionResult Create(child child1)
        {
            
            try
            {
               // child1.gender = (int)ViewData["Gender"];
                _dao.CreateChildData(child1);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }





        /// 

        [HttpGet]
        public ActionResult CreateMothertest()
        {

            
            return View();
                }

        [HttpPost]
        public ActionResult CreateMothertest(mother mother)
        {
            MotherDAO _daom = new MotherDAO();
            try
            {
                // child1.gender = (int)ViewData["Gender"];
                _daom.CreateMotherData(mother);
                return RedirectToAction("Create");

            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Create");
        }

        public ActionResult IndexMother()
        {
            return View(MotherDAO.GetMother());
        }

        ///


        // GET: Child/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Child/Edit/5
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

        // GET: Child/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Child/Delete/5
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
