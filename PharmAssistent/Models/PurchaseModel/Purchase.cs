using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using PharmAssistent.Models;
using System.Linq;
using System.Web;

namespace PharmAssistent.Models.PurchaseModel
{
    [Table("Purchase")] 
    public class Purchase
    {
        [Key]
        [Display(Name = "Invoice No")]
        public int ID { get; set; }
        public string PurchaseID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierID { get; set; }

        public decimal Amount { get; set; }

        [Range(0.00, 99999999.99)]
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        public bool IsPaid { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated { get; set; }
        public string Description { get; set; }

      public virtual Supplier Supplier { get; set; }
     //  public virtual ICollection<PurchaseItem> PurchaseItemList { get; set; }


    }
}


