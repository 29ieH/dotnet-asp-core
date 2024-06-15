using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    public class StudentController(IStudentService studentService, IDepartmentService departmentService) : Controller
    {

        private readonly IStudentService _studentService = studentService;
        private readonly IDepartmentService _departmentService = departmentService;
        public IActionResult Index(String? keySearch = null, int? DepartmentId = null)
        {
            ViewBag.Departments = _departmentService.GetDepartments();
            List<Student> students = _studentService.GetStudents();
            students = students.Where(st => keySearch.IsNullOrEmpty() || st.Name.Contains(keySearch) ||
            st.Code.Contains(keySearch) || st.Address.Contains(keySearch)
            )
            .Where(st => DepartmentId is null || st.DepartmentId == DepartmentId).ToList();
            return View(students);
        }
        public IActionResult Create(int? id)
        {
            Student? studentUpdate = _studentService.GetStudentById(id ?? 0);
            if (studentUpdate != null)
            {
                ViewBag.student = studentUpdate;
            }
            return View(_departmentService.GetDepartments());
        }
        public IActionResult Update(int id)
        {
            Student? studentUpdate = _studentService.GetStudentById(id);
            if (studentUpdate != null)
            {
                ViewBag.student = studentUpdate;
            }
            return View(_departmentService.GetDepartments());
        }
        public IActionResult Save(Student student)
        {
            Console.WriteLine(student.Id);
            if (student.Id != 0)
            {
                _studentService.UpdateStudent(student);
                Console.WriteLine("Check update");
            }
            else
            {
                _studentService.CreateStudent(student);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}