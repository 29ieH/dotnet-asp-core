using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    public class DepartmentController(IDepartmentService departmentService) : Controller
    {
        private readonly IDepartmentService _departmentService = departmentService;
        public IActionResult Index(int? DepartmentId = null)
        {
            if (DepartmentId != null)
            {
                ViewBag.Department = _departmentService.GetDepartmentById(DepartmentId ?? 0);
            }
            return View(_departmentService.GetDepartments());
        }
        public IActionResult Detail(int id)
        {
            return View(_departmentService.GetDepartmentById(id));
        }
        public IActionResult Delete(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}