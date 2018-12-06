using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebAppV2.Models;

namespace WebApp.Controllers
{
    public class ChildController : Controller
    {
        private readonly ChildDAO _dao = new ChildDAO();
        // GET: Child
        public ActionResult Index()
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                child child_model = new child();
                child_model.momnameslist = ctx.mother.ToList<mother>();
                mother mother_model = new mother();
                string query = "select m.* from mother m inner join child c on c.mother_id=m.mother_id";
                List<mother> mlist = ctx.Database.SqlQuery<mother>(query).ToList();
                foreach(mother el in mlist)
                {
                    el.fio = el.mother_name + " " + el.mother_surname + " " + el.mother_patronymic;
                }
                string fquery = "select f.* from father f inner join child c on c.father_id=f.father_id";
                List<father> flist = ctx.Database.SqlQuery<father>(fquery).ToList();
                foreach (father el in flist)
                {
                    el.fio = el.father_surname + " " + el.father_name + " " + el.father_patronymic;
                }
                ViewData["motherFIO"] = mlist;
                ViewData["fatherFIO"] = flist;
                List<child> list_child = ChildDAO.GetChild();

            return View(list_child);
            }
        }


        // GET: Child/Details/5
        public ActionResult Details(int id)
        {

            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                string momquery = string.Format("select m.* from mother m inner join child c on c.mother_id=m.mother_id where c.child_id={0}",id);
                
                string dadquery = string.Format("select f.* from father f inner join child c on c.father_id=f.father_id where c.child_id={0}", id);
                string groupquery = string.Format("select g.* from [group] g inner join child c on c.group_id = g.group_id where c.child_id={0}",id);
                List<mother> mlist = ctx.Database.SqlQuery<mother>(momquery).ToList();
                mother mother = mlist.ElementAt(0);
                List<father> flist = ctx.Database.SqlQuery<father>(dadquery).ToList();
                father father = flist.ElementAt(0);
                List<group> glist = ctx.Database.SqlQuery<group>(groupquery).ToList();
                group group = glist.ElementAt(0);
                //List<mother> flist = ctx.Database.SqlQuery<mother>(dadquery).ToList();
                //List<mother> glist = ctx.Database.SqlQuery<mother>(groupquery).ToList();
                ViewData["mother"] = mlist;
                ViewData["father"] = flist;
                ViewData["group"] = glist;
            }

            return View(ChildDAO.getById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            child child_model = new child();

            mother mothermodel = new mother();
            father fathermodel = new father();
            group groupmodel = new group();

            using (kindergartenEntities db = new kindergartenEntities())
            {
                child_model.momnameslist = db.mother.ToList<mother>();
                child_model.dadnameslist = db.father.ToList<father>();
                child_model.groupslist = db.group.ToList<group>();

                foreach (mother el in child_model.momnameslist)
                {
                    el.fio = el.mother_surname + " " + el.mother_name + " " + el.mother_patronymic;
                }
                foreach (father el in child_model.dadnameslist)
                {
                    el.fio = el.father_surname + " " + el.father_name + " " + el.father_patronymic;
                }
                foreach (group el in child_model.groupslist)
                {
                    el.name = el.group_children_age + " " + el.group_profile;
                }



            }

            return View(child_model);

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

        // // // // // // // //

        [HttpGet]
        public ActionResult CreateFather()
        {


            return View();

        }
        [HttpPost]
        public ActionResult CreateFather(father father)
        {
            FatherDAO _daom = new FatherDAO();
            try
            {
                // child1.gender = (int)ViewData["Gender"];
                _daom.CreateFatherData(father);
                return RedirectToAction("Create");

            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Create");
        }

        public ActionResult IndexFather()
        {
            return View(FatherDAO.GetFather());
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
