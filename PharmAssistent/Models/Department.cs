using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmAssistent.Models
{
    [Table("tblId")]
    public class Department
    {
        [Range(1, 3)]
        [Required]
        [Display(Name = "Enter Range Between 1 - 3")]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee> Employee { get; set; }
    }
}