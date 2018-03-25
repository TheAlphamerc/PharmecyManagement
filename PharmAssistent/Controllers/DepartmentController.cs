using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using PharmAssistent.Models;

namespace PharmAssistent.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Department> departments = employeeContext.Department.ToList();
            //    employeeContext.Employees.Select(m => m.EmpId).Count();

            return View(departments);
        }

    }
}