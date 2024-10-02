using EmployeeM.Data;
using EmployeeM.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeM.Controllers
{
    public class DepartmentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<DepartmentEntity> Departments = new List<DepartmentEntity>();

            DepartmentRepository DepartmentRepository = new DepartmentRepository();
            {

                Departments = DepartmentRepository.GetAllDepartments();
            }

            return View(Departments);
        }
    }
}
