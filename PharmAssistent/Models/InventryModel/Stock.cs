using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PharmAssistent.Models.PurchaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmAssistent.Models.InventoryModel
{
    [Table("Stock")]
    public class Stock
    {
        public Stock()
        {

            Stop_Notification = true;
            //ItemExpired = false;
        }
        [Key]
        public int ID { get; set; }
        [Required]
        public int ItemID { get; set; }

        [StringLength(20, ErrorMessage = "Too long. Plese check again!")]
        public string Batch { get; set; }

        [Range(0, 9999999)]
        public int Qty { get; set; }

        //[Required]
        //[Range(0, 100000)]
        //public int Qty { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Out of range!")]
        public decimal CostPrice { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Out of range!")]
        public decimal SellingPrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ManufactureDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Expiry { get; set; }

        [NotMapped]
        public bool ItemExpired { get; set; }
        [NotMapped]
        public bool Stop_Notification { get; set; }
     
        public string PurchaseID { get; set; }


        //references
        public virtual Item Item { get; set; }
    }
}