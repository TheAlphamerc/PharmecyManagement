using PharmAssistent.Models;
using PharmAssistent.Models.PurchaseModel;
using PharmAssistent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmAssistent.Service
{
    public class PurchaseEntryService
    {
        private PurchaseEntryRepository repo = new PurchaseEntryRepository();

        public void AddPurchaseAndPurchseItems(Purchase p)
        {
            repo.AddPurchaseAndPurchseItems(p);
        }
     //   update inventory
      public void InsertOrUpdateInventory(List<PurchaseItem> pi)
        {
            PharmContext dba = new PharmContext();
            foreach (PurchaseItem item in pi)
            {
                dba.PurchaseItemContext.Add(item);
                dba.SaveChanges();
                repo.InsertOrUpdateInventory(item);
            }


        }
    }
}