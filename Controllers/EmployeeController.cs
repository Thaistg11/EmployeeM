using EmployeeM.Data;
using EmployeeM.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpolyeeM.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<EmployeeEntity> Employee = new List<EmployeeEntity>();

            EmployeeRepository EmployeeRepository = new EmployeeRepository();

            Employee = EmployeeRepository.GetAllEmployee();

            return View(Employee);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();  // Returns the AddEmployee form view
        }


        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(EmployeeEntity EmployeeDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository _DbEmployee = new EmployeeRepository();
                    if (_DbEmployee.AddEmployee(EmployeeDetails))
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(EmployeeDetails);
            }
            catch
            {
                return View(EmployeeDetails);
            }
        }

    }
}