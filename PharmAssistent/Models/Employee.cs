using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmAssistent.Models
{
    [Table("tblId")]
    public class Emp
    {
        [Required]
        public string DepartmentName { get; set; }
    }
  
    [Table("spSingleEmployeeView")]
    public class Employee : Emp
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public new string DepartmentName { get; set; }
    }


}