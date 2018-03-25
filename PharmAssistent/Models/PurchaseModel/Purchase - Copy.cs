using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using PharmAssistent.Models;
using System.Linq;
using System.Web;

namespace PharmAssistent.Models.PurchaseModel
{
    [Table("PurchaseItem")]
    public class Purchase_Copy
    {


        public Purchase_Copy()
        {
            this.IsPaid = "true";
        }
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Supplier")]
        public int SupplierID { get; set; }

        [Key]
        [Display(Name = "Invoice No")]
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Item")]
        public int ItemID { get; set; }
        public int Batch { get; set; }
        public int Qty { get; set; }

        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Expiry { get; set; }
        [Range(0.00, 99999999.99)]
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        public string IsPaid { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated { get; set; }

        public List<PurchaseItem> PurchaseItem { get; internal set; }

    }
}


//    [Range(0.00, 99999999.99)]




//public virtual Supplier Supplier { get; set; }
//public virtual ICollection<PurchaseModel.PurchaseItem> PurchaseItems { get; set; }


//    public class pt
//    {
//        public DateTime LastUpdated { get; internal set; }
//        public List<PurchaseItem> PurchaseItems { get; internal set; }
//    };

