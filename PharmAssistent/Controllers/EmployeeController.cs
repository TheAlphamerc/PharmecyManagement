using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmAssistent.Models;

namespace MVCDEMO.Controllers
{
    public class EmployeeController : Controller 
    {
        // GET: Employee
        public ActionResult Index(int departmentId)
        {
            EmployeeContext employeContext = new EmployeeContext();
            List<Employee> employees = employeContext.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();

            return View(employees);
         

        }
        public ActionResult Details(int id)
        {
            EmployeeContext employeContext = new EmployeeContext();
            Employee employee = employeContext.Employees.Single(emp => emp.EmpId == id);

          
            return View(employee);

        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee employee = new Employee();
            TryUpdateModel(employee);
            //if (ModelState.iIsValid)
            //{
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);   // @Html.ActionLink("Back to List", "Index", new { departmentId = Model.DepartmentId })

                return RedirectToAction("ShowAll", "Employee");
            //}

            //return View();

        }

        public ActionResult ShowAll()
        {
            EmployeeBusinessLayer employeeBussinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBussinessLayer.Employees.ToList();
            EmployeeContext db = new EmployeeContext();
            var data = db.Employees.SqlQuery("spGetEmployeeData").ToList();
            return View(data);
         /*   return View(employees)*/;
        }
        public ActionResult Search(String Search)
        {
            Employee employee = new Employee();
            EmployeeContext db = new EmployeeContext();
            EmployeeBusinessLayer employeeBussinessLayer = new EmployeeBusinessLayer();
            var emp = from m in db.Employees select m;
            if (!String.IsNullOrEmpty(Search))
            {
                emp = emp.Where(m => m.Name.Contains(Search));
            }



            return View(emp);

        }

        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            ViewBag.msg = "Employee Deleted SuccessFully";
            return RedirectToAction("ShowAll", "Employee");
        }
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.EmpId == id);

            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(Employee employee)
        {

            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.SaveEmployee(employee);
            return RedirectToAction("ShowAll", "Employee");

        }




    }
}
