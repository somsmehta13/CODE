using CRUD2.Context;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CRUD2.Controllers
{
    public class EmployeeController : Controller

    {

        ImageEntities2 dbobj = new ImageEntities2();
        public ActionResult Employee(Employee obj)
        {

           

            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            Employee obj = new Employee();

            if (ModelState.IsValid)
            {

                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                if (model.ID == 0)

                {
                    dbobj.Employee.Add(obj);
                    dbobj.SaveChanges();

                }
                else
                {
                    dbobj.Entry(obj).State = EntityState.Modified;
                   dbobj.SaveChanges();
                }
                ModelState.Clear();
            }
            return View("Employee");
        }


        public ActionResult EmployeeList()
        {
            var res = dbobj.Employee.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbobj.Employee.Where(x => x.ID == id).First();
            dbobj.Employee.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.Employee.ToList();

            return View("EmployeeList", list);
           }
    }

}