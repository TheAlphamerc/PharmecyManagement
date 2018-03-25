using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;


namespace PharmAssistent.Models 
{
    [Table("Supplier")]
    public class Supplier
    {
        public Supplier()
        {
            this.Address = "N/A";
            this.Contact = 0 ;
            this.Description = "N/A";
            this.Name  = "N/A";

            this.ID = 1;
        }
        [Key]
        public int ID { get; set; }
        [Display(Name = "Supplier")]
        [Required]
        [StringLength(50, ErrorMessage = "Only 50 characters allowed!")]
        public string Name { get; set; }

        public string Address { get; set; }
        public int Contact { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<Purchase> Purchases { get; set; }
    }

}