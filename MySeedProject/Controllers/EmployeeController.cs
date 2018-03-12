using Inspinia_MVC5_SeedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDB empDB = new EmployeeDB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAll().Find(x => x.EmployeeID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCities()
        {
            List<Cities> myCities = new List<Cities>();

            myCities.Add(
                new Cities()
                {
                    id = 1,
                    city = "abha"
                });

            myCities.Add(
                new Cities()
                {
                    id = 2,
                    city = "tabuk"
                });

            myCities.Add(
                new Cities()
                {
                    id = 3,
                    city = "jeddah"
                });

            myCities.Add(
                new Cities()
                {
                    id = 4,
                    city = "madina"
                });


            return Json(myCities, JsonRequestBehavior.AllowGet);
        }
    }
}