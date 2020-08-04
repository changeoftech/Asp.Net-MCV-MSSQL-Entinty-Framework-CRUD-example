using RegisterTestApp.Business;
using RegisterTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterTestApp.Controllers
{
    public class BilgiController : Controller
    {

        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Bilgi bilgiler)
        {
            NWBusinessLogic nwBusiness = new NWBusinessLogic();
            nwBusiness.Save(bilgiler);
            return View();
        }

        [HttpGet]
        public ActionResult Select()
        {
            NWBusinessLogic nwBusiness = new NWBusinessLogic();
            return View(nwBusiness.List());
        }

        public ActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Edit(Bilgi bilgi)
        {
            using (var ctx = new TestDatabaseEntities())
            {
                if (ModelState.IsValid)
                {
                    NWBusinessLogic nwBusiness = new NWBusinessLogic();
                    nwBusiness.Update(bilgi);
                }
                return View();
            }
        }


        public ActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(Bilgi bilgi)
        {
            using (var ctx = new TestDatabaseEntities())
            {
                if (ModelState.IsValid)
                {
                    NWBusinessLogic nwBusiness = new NWBusinessLogic();
                    nwBusiness.Delete(bilgi);
                }
                return View();
            }
        }
    }
}