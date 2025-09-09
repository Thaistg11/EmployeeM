using EmployeeM.Data;
using EmployeeM.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeM.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _departmentRepository;

        // Constructor injection
        public DepartmentController(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAllDepartments();
            return View(departments);
        }
    }
}
