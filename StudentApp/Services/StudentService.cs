using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student? GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
public class StudentService(DataContext dataContext) : IStudentService
{
    private readonly DataContext _dataContext = dataContext;
    public void CreateStudent(Student student)
    {
        _dataContext.Students.Add(student);
        _dataContext.SaveChanges();
    }

    public void DeleteStudent(int id)
    {
        var student = _dataContext.Students.FirstOrDefault(x => x.Id == id);
        if (student is null) return;
        _dataContext.Students.Remove(student);
        _dataContext.SaveChanges();
    }

    public Student? GetStudentById(int id)
    {
        return _dataContext.Students.FirstOrDefault(x => x.Id == id);
    }

    public List<Student> GetStudents()
    {
        return _dataContext.Students.Include(st => st.Department).ToList();
    }

    public void UpdateStudent(Student student)
    {
        var UpdateStudent = _dataContext.Students.FirstOrDefault(x => x.Id == student.Id);
        if (UpdateStudent is null) return;
        if (student.Code != null) UpdateStudent.Code = student.Code;
        if (student.Name != null) UpdateStudent.Name = student.Name;
        UpdateStudent.Birthday = student.Birthday;
        if (student.DepartmentId != 0) UpdateStudent.DepartmentId = student.DepartmentId;
        _dataContext.SaveChanges();
    }
}