using EmpolyeeM.Data;
using EmpolyeeM.Models;
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

        public ActionResult AddEmployee()
        {
            return View();
        }
        public ActionResult AddEmployee(EmployeeEntity EmployeeDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository _DbEmployee = new EmployeeRepository();
                    if (_DbEmployee.AddEmployee(EmployeeDetails))
                    {
                        return RedirectToAction("index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    
    }
}
