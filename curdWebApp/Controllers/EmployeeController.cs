
using curdWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace curdWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IConfiguration configuration;
        EmployeeDAL employeeDAL;

        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeeDAL = new EmployeeDAL(this.configuration);
        }
        [HttpGet]
        public IActionResult EmployeeList()
        {
            var model = employeeDAL.GetAllEmployee();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Create(Employee emp)
        {
            try
            {
                int result = employeeDAL.AddEmployee(emp);
                if (result == 1)
                {
                    return RedirectToAction("EmployeeList");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = employeeDAL.GetEmployeeById(id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                int result = employeeDAL.UpdateEmployee(emp);
                if (result == 1)
                {
                    return RedirectToAction("EmployeeList");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cust = employeeDAL.GetEmployeeById(id);
            return View(cust);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = employeeDAL.DeleteEmployee(id);
                if (result == 1)
                {
                    return RedirectToAction("EmployeeList");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var emp = employeeDAL.GetEmployeeById(id);
            return View(emp);
        }
    }
}
