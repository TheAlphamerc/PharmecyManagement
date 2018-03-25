using PharmAssistent.Models;

using PharmAssistent.Models.PurchaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmAssistent.ViewModel
{

 //   [Table("Purchase")]
    public class PurchaseEntryVM
    {
      //  PharmContext db = new PharmContext();
        [Key]
        public int ID { get; set; }
        public string PurchaseID { get; set; }
        public DateTime Date { get; set; }
        public int SupplierID { get; set; }
        public decimal Amount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }   
        public decimal GrandTotal { get; set; }
        public bool IsPaid { get; set; }
        public string Description { get; set; }
      public DateTime LastUpdated { get; set; }
        
     public List<PurchaseItem> PurchaseItems { get; set; }

    }
}