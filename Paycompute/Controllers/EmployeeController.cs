using Microsoft.AspNetCore.Mvc;
using Paycompute.Models;
using Paycompute.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paycompute.Controllers
{
    public class EmployeeController :Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll()
                .Select(employee => new EmployeeIndexViewModel

                {
                    Id = employee.Id,
                    EmployeeNo = employee.EmployeeNo,
                    ImageUrl = employee.FullName,
                    Gender = employee.Designation,
                    City = employee.City,
                    DateJoined = employee.DateJoined
                }).ToList();
            return View(employees);
        }
    }
}
