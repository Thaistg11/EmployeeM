using EmployeeM.Data;
using EmployeeM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace EmployeeM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly DepartmentRepository _departmentRepository;

        // ✅ Constructor injection
        public EmployeeController(EmployeeRepository employeeRepository, DepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index(string SearchString)
        {
            List<EmployeeEntity> Employee = new List<EmployeeEntity>();

            if (!User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(SearchString))
                {
                    Employee = _employeeRepository.GetEmployeeByDepartmentFilter(userId, SearchString);
                }
                else
                {
                    Employee = _employeeRepository.GetEmployeeByDepartment(userId);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    Employee = _employeeRepository.GetEmployeeByFilter(SearchString);
                }
                else
                {
                    Employee = _employeeRepository.GetAllEmployee();
                }
            }

            return View(Employee);
        }

        [HttpGet]
        public IActionResult EditEmployee(int Id)
        {
            var Employee = _employeeRepository.GetEmployeeById(Id);
            var departments = _departmentRepository.GetAllDepartments();

            ViewBag.Departments = new SelectList(departments, "Id", "Name", Employee.DepartmentId);
            return View("EditEmployee", Employee);
        }

        [HttpPost]
        public IActionResult EditEmployeeDetails(int Id, EmployeeEntity EmployeeDetails)
        {
            if (ModelState.IsValid)
            {
                if (_employeeRepository.EditEmployeeDetails(Id, EmployeeDetails))
                {
                    return RedirectToAction("Index");
                }
            }

            var departments = _departmentRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", EmployeeDetails.DepartmentId);
            return View(EmployeeDetails);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            var departments = _departmentRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeEntity EmployeeDetails)
        {
            if (ModelState.IsValid)
            {
                if (_employeeRepository.AddEmployee(EmployeeDetails))
                {
                    return RedirectToAction("Index");
                }
            }

            var departments = _departmentRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View(EmployeeDetails);
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int Id)
        {
            var Employee = _employeeRepository.GetEmployeeById(Id);
            var departments = _departmentRepository.GetAllDepartments();

            ViewBag.Departments = new SelectList(departments, "Id", "Name", Employee.DepartmentId);
            return View("DeleteEmployee", Employee);
        }

        [HttpPost]
        public IActionResult DeleteEmployeeDetails(int Id)
        {
            if (ModelState.IsValid)
            {
                if (_employeeRepository.DeleteEmployeeDetails(Id))
                {
                    return RedirectToAction("Index");
                }
            }

            return View("DeleteEmployee");
        }
    }
}
