using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppV2.Models;

namespace WebAppV2.Controllers
{
    public class MethodistController : Controller
    {
        // GET: Methodist
        public ActionResult Index()
        {
            using (kindergartenEntities ctx = new kindergartenEntities())
            {
                
            }


            return View();
        }


    }
}