
using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Student()
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Code { get; set; } = String.Empty;
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        public DateOnly Birthday { get; set; } = DateOnly.MinValue;
        [MaxLength(255)]
        public string? Address { get; set; } = String.Empty;
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}