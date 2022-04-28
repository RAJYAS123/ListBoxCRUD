using ListBoxCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListBoxCRUD.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            List<Designation> DeptList = db.Designations.ToList();
            ViewBag.ListOfDepartment = new SelectList(DeptList, "designationid", "designation");
            return View();
        }

        [HttpGet]
        public JsonResult GetEmployee()
        {
            var contacts = db.Employees.Select(x => new
            {
                name = x.name,
                employeeid = x.employeeid

            }).ToList();
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveDataInDatabase(EmployeeTB model)
        {


            Employee Stu = new Employee();
            Stu.name = model.name;
            Stu.designationid = model.designationid;
            Stu.salary = model.salary;
            Stu.address = model.address;
            db.Employees.Add(Stu);
            var i = db.SaveChanges();
            return Json(Stu, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEmployeeByID(int employeeid)
        {

            EmployeeTB employee = new EmployeeTB();
            var emp = (from c in db.Employees
                       where c.employeeid == employeeid
                       select c).FirstOrDefault();
            if (emp == null)
            {
                return Json(false);
            }
            else
            {
                employee.name = emp.name;
                employee.designationid = emp.designationid;
                employee.salary = emp.salary;
                employee.address = emp.address;
                return Json(employee, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Update(EmployeeTB model)
        {

            Employee updated = (from c in db.Employees
                                where c.employeeid == model.employeeid
                                select c).FirstOrDefault();
            updated.name = model.name;
            updated.designationid = model.designationid;
            updated.salary = model.salary;
            updated.address = model.address;
            db.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public JsonResult Delete(int employeeid)
        {
            Employee data = (from c in db.Employees
                             where c.employeeid == employeeid
                             select c).FirstOrDefault();
            db.Employees.Remove(data);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}