using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using StudentApp.Services;

namespace StudentApp.Services
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        Department? GetDepartmentById(int id);
        void DeleteDepartment(int id);
    }
}
class DepartmentService(DataContext dataContext) : IDepartmentService
{
    private readonly DataContext _dataContext = dataContext;

    public void DeleteDepartment(int id)
    {
        Department? department = _dataContext.Departments.Find(id);
        if (department != null)
        {
            _dataContext.Departments.Remove(department);
            _dataContext.SaveChanges();
        }
    }
    public Department? GetDepartmentById(int id)
    {
        return _dataContext.Departments.Include(d => d.Students).FirstOrDefault(d => d.Id == id);
    }

    public List<Department> GetDepartments()
    {
        return _dataContext.Departments.Include(d => d.Students).ToList();
    }
}