using PharmAssistent.Models.PurchaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace PharmAssistent.Models.InventoryModel  
{
    [Table("Item")]
    public class Item
    {
        [Key]
        [Display(Name = "Item No")]
        public int ID { get; set; }

        [Required]
        [Display(Name="Item")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Generic Name")]
        public int? DrugGenericNameID { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public int? ManufacturerID { get; set; }
         
        [Required]
        [Display(Name = "Categeory")]
        public string Categeory { get; set; }   


        public int AlertQty { get; set; }
        public string Description { get; set; }

        [Display(Name = "Last Update")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated { get; set; }


        //reference entity
        public virtual DrugGenericName DrugGenericName { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        //public virtual ICollection<Stock> Stocks { get; set; }
  // COMENT      public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }

    }
    public enum Categeory
    {
        Drug,
        Supplies,
        other
    }

    public enum Measurement
    {
        ml, mg, gm, kg, others

    }

    public enum UnitType
    {
        pkg, file, pcs, other
    }
}


