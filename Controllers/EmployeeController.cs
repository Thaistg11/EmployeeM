﻿using EmployeeM.Data;
using EmployeeM.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpolyeeM.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(string SearchString)
        {
            List<EmployeeEntity> Employee = new List<EmployeeEntity>();
            EmployeeRepository EmployeeRepository = new EmployeeRepository();

            // Check if any of the filter parameters are populated
            if (!String.IsNullOrEmpty(SearchString))
            {
                // If any filter parameters are populated, call GetEmployeeByFilter
                Employee = EmployeeRepository.GetEmployeeByFilter(SearchString);
            }
            else
            {
                // If none of the filter parameters are populated, call GetAllEmployee
                Employee = EmployeeRepository.GetAllEmployee();
            }

            return View(Employee);
        }


        [HttpGet]
        public IActionResult EditEmployee (int Id)
        {
            EmployeeEntity Employee = new EmployeeEntity();

            EmployeeRepository EmployeeRepository = new EmployeeRepository();

            Employee = EmployeeRepository.GetEmployeeById(Id);

            return View("EditEmployee", Employee);
        }


        [HttpPost]
        public IActionResult EditEmployeeDetails(int Id, EmployeeEntity EmployeeDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository _DbEmployee = new EmployeeRepository();
                    if (_DbEmployee.EditEmployeeDetails(Id, EmployeeDetails))
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

        [HttpGet]
        public ActionResult DeleteEmployee(int Id) 
        {
            EmployeeEntity Employee = new EmployeeEntity();

            EmployeeRepository EmployeeRepository = new EmployeeRepository();

            Employee = EmployeeRepository.GetEmployeeById(Id);

            return View("DeleteEmployee", Employee);
      
        }

        [HttpPost]
        public IActionResult DeleteEmployeeDetails(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository _DbEmployee = new EmployeeRepository();
                    if (_DbEmployee.DeleteEmployeeDetails(Id))
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(DeleteEmployee);
            }
            catch
            {
                return View(DeleteEmployee);
            }
        }

    }
}