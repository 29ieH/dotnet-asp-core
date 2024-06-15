using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class Department()
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public String Name { get; set; } = String.Empty;

        public virtual List<Student> Students { get; set; } = [];
    }
}