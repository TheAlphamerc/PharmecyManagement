using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using PharmAssistent.Models.InventoryModel;
using PharmAssistent.Models.PurchaseModel;
using PharmAssistent.Models.SellsModel;
using PharmAssistent.ViewModel;

namespace PharmAssistent.Models
{
    public class PharmContext : DbContext
    {
        //DbSet<PharmAssistent.Models.Supplier> Suppliers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<PurchaseItem> PurchaseItemContext { get; set; }
   //     public DbSet<VM> PurchaseEntryVMContext { get; set; }

        public DbSet<Purchase> PurchaseContext { get; set; }

        public DbSet<DrugGenericName> DrugGenericNames { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Sales> SellsContext { get; set; }
        public DbSet<SalesItem> SellsItemContext { get; set; }

    }
}